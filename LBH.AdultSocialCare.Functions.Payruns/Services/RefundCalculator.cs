using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Extensions;

namespace LBH.AdultSocialCare.Functions.Payruns.Services
{
    public static class RefundCalculator
    {
        public static RefundInfo Calculate(IPackageItem packageItem, IList<InvoiceDomain> packageInvoices, PaymentPeriod paymentPeriod)
        {
            var existingInvoiceItems = packageInvoices
                .SelectMany(invoice => invoice.Items)
                .Where(packageItem.IsReferenced)
                .ToList();

            if (!existingInvoiceItems.Any()) return RefundInfo.Empty;

            // package item has some significant updates (cost, dates etc.) -> create a new refund
            if (packageItem.Version > existingInvoiceItems.Max(item => item.SourceVersion))
            {
                // calculate new cost for package item Start / End date range
                // or till last invoice end date (for ongoing package items).
                var lastInvoiceEndDate = packageInvoices.Max(invoice => invoice.EndDate);

                var refundStartDate = packageItem.StartDate;
                var refundEndDate = Dates.Min(packageItem.EndDate, lastInvoiceEndDate);

                var quantity = Dates.WeeksBetween(refundStartDate, refundEndDate);

                var refund = new RefundInfo
                {
                    StartDate = refundStartDate,
                    EndDate = refundEndDate,
                    Quantity = quantity,
                    CurrentCost = paymentPeriod is PaymentPeriod.OneOff
                        ? packageItem.Cost
                        : packageItem.Cost * quantity
                };

                switch (packageItem)
                {
                    case CarePackageDetail _:
                        CalculateDetailRefundAmount(refund, existingInvoiceItems);
                        break;

                    case CarePackageReclaim reclaim:
                        CalculateReclaimRefundAmount(reclaim, refund, existingInvoiceItems);
                        break;
                }

                return refund;
            }

            return RefundInfo.Empty;
        }

        private static void CalculateDetailRefundAmount(RefundInfo refund, IList<InvoiceItem> existingInvoiceItems)
        {
            var paidTotal = existingInvoiceItems.Sum(item => item.TotalCost);

            refund.RefundAmount = refund.CurrentCost - paidTotal;
        }

        private static void CalculateReclaimRefundAmount(CarePackageReclaim reclaim, RefundInfo refund, IList<InvoiceItem> existingInvoiceItems)
        {
            // when switching from Net to Gross we must refund everything from supplier
            // and ignore upcoming Hackney's reclaims. After switching back to Net
            // we must generate refunds starting from previous compensation point.
            existingInvoiceItems = existingInvoiceItems
                .OrderByDescending(item => item.SourceVersion) // take just new items
                .TakeWhile(item => !item.NetCostsCompensated) // after previous compensation checkpoint
                .ToList();

            // total amount deducted from supplier for a given period
            var deductedNetCost = existingInvoiceItems
                .Where(item => item.ClaimCollector is ClaimCollector.Supplier)
                .Sum(item => item.TotalCost);

            // total amount of refunds to/from supplier for a given period
            var refundedCost = existingInvoiceItems
                .Where(item => item.ClaimCollector is null)
                .Sum(item => item.TotalCost);

            switch (reclaim.ClaimCollector)
            {
                case ClaimCollector.Supplier:
                    // previously deducted costs + (overpaid - underpaid) - current cost
                    refund.RefundAmount = deductedNetCost - refundedCost - refund.CurrentCost;
                    break;

                case ClaimCollector.Hackney when !existingInvoiceItems.First().NetCostsCompensated:
                    // we're switching from Net to Gross - refund everything from supplier and create a compensation checkpoint
                    refund.RefundAmount = refundedCost - deductedNetCost;
                    refund.NetCostsCompensated = true;
                    break;

                case ClaimCollector.Hackney:
                    refund.RefundAmount = 0.0m;
                    break; // we've compensated all Net costs already and still in Gross mode - no need to refund anything
            }
        }
    }
}
