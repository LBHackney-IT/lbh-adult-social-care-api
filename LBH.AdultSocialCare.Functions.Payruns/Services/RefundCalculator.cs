using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
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
        public static IEnumerable<RefundInfo> Calculate(
            IPackageItem packageItem, IList<InvoiceDomain> packageInvoices,
            Func<DateTimeOffset, DateTimeOffset, decimal, decimal> calculateCurrentCost)
        {
            var paidInvoiceItems = GetPaidInvoiceItems(packageItem, packageInvoices);
            if (!paidInvoiceItems.Any()) yield break;

            // package item has some significant updates (cost, dates etc.) -> create a new refund
            if (packageItem.Version > paidInvoiceItems.Max(item => item.SourceVersion))
            {
                // always create a refund in range of first invoice to avoid
                // tricky cases with jagged diapasons of refunds / rejected / normal items
                // [--inv1--][--inv2--][--inv2--]
                // [--ref1--][--ref2--][--ref2--]
                var invoiceItemsGroups = paidInvoiceItems.GroupBy(item => item.FromDate);

                foreach (var group in invoiceItemsGroups)
                {
                    var currentStartDate = packageItem.StartDate;
                    var currentEndDate = Dates.Min(packageItem.EndDate, group.First().FromDate);

                    // if package item date range moved into future, its start date can be greater than last invoice date
                    // no payments now needed for new range, but we still need to refund already paid.
                    // So set quantity and current cost to 0 and let the rest of logic flow.
                    var quantity = Math.Max(Dates.WeeksBetween(currentStartDate, currentEndDate), 0);

                    var refund = new RefundInfo
                    {
                        StartDate = group.First().FromDate,
                        EndDate = group.First().ToDate,
                        Quantity = quantity,
                        CurrentCost = quantity > 0
                            ? calculateCurrentCost(currentStartDate, currentEndDate, quantity)
                            : 0.0m // prevent generation for one-offs not dependent on quantity
                    };

                    switch (packageItem)
                    {
                        case CarePackageDetail _:
                            CalculateDetailRefundAmount(refund, group.ToList());
                            break;

                        case CarePackageReclaim reclaim:
                            CalculateReclaimRefundAmount(reclaim, refund, group.ToList());
                            break;
                    }

                    yield return refund;
                }
            }
        }

        private static void CalculateDetailRefundAmount(RefundInfo refund, IList<InvoiceItem> paidInvoiceItems)
        {
            var paidTotal = paidInvoiceItems.Sum(item => item.TotalCost);

            refund.RefundAmount = refund.CurrentCost - paidTotal;
        }

        private static void CalculateReclaimRefundAmount(CarePackageReclaim reclaim, RefundInfo refund, IList<InvoiceItem> paidInvoiceItems)
        {
            // when switching from Net to Gross we must refund everything from supplier
            // and ignore upcoming Hackney's reclaims. After switching back to Net
            // we must generate refunds starting from previous compensation point.
            var actualInvoiceItems = paidInvoiceItems
                .OrderByDescending(item => item.SourceVersion) // take just new items
                .TakeWhile(item => !item.NetCostsCompensated) // after previous compensation checkpoint
                .ToList();

            // total amount deducted from supplier for a given period
            var deductedNetCost = actualInvoiceItems
                .Where(item => item.ClaimCollector is ClaimCollector.Supplier)
                .Sum(item => item.TotalCost);

            // total amount of refunds to/from supplier for a given period
            var refundedCost = actualInvoiceItems
                .Where(item => item.ClaimCollector is null)
                .Sum(item => item.TotalCost);

            if (reclaim.Status is ReclaimStatus.Cancelled)
            {
                // compensate remainders to / from supplier
                refund.RefundAmount = refundedCost - deductedNetCost;
                refund.NetCostsCompensated = true;
            }
            else
            {
                switch (reclaim.ClaimCollector)
                {
                    case ClaimCollector.Supplier:
                        refund.RefundAmount = deductedNetCost != 0
                            ? deductedNetCost - refundedCost - refund.CurrentCost   // previously deducted costs + (overpaid - underpaid) - current cost
                            : refundedCost + refund.CurrentCost;                    // nothing deducted -> switch from Hackney to supplier, just accumulate everything // TODO: VK: Review
                        break;

                    case ClaimCollector.Hackney when !actualInvoiceItems.Any(item => item.NetCostsCompensated):
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

        private static List<InvoiceItem> GetPaidInvoiceItems(IPackageItem packageItem, IList<InvoiceDomain> packageInvoices)
        {
            return packageInvoices
                .Where(invoice => invoice.Status is InvoiceStatus.Accepted &&
                                  invoice.PayrunStatus.In(PayrunStatus.Paid, PayrunStatus.PaidWithHold, PayrunStatus.Approved))
                .SelectMany(invoice => invoice.Items)
                .Where(packageItem.IsReferenced)
                .ToList();
        }
    }
}
