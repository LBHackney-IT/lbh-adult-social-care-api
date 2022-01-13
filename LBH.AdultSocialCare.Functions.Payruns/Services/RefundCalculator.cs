using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants;
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
        public static IEnumerable<Refund> Calculate(
            IPackageItem packageItem, IList<InvoiceDomain> packageInvoices,
            Func<DateRange, decimal, decimal> calculateCurrentCost)
        {
            var paidInvoiceItems = GetPaidInvoiceItems(packageItem, packageInvoices);
            if (!paidInvoiceItems.Any()) yield break; // no payments. no refunds

            // package item has some significant updates (cost, dates etc.) -> create a new refund
            if (packageItem.Version > paidInvoiceItems.Max(item => item.SourceVersion))
            {
                // handle possible shift of package item start date before first paid invoice
                var refund = TryRefundBeforeFirstPaidDate(packageItem, paidInvoiceItems, calculateCurrentCost);
                if ((refund != null) && (refund.Amount != 0.0m)) yield return refund;

                // always create a refund in range of first invoice to avoid
                // tricky cases with jagged diapasons of refunds / rejected / normal items
                // [--inv1--][--inv2--][--inv2--]
                // [--ref1--][--ref2--][--ref2--]
                var invoiceItemsGroups = paidInvoiceItems.GroupBy(item => item.FromDate);

                foreach (var paidItems in invoiceItemsGroups)
                {
                    var currentRange = new DateRange(
                        Dates.Max(packageItem.StartDate, paidItems.First().FromDate),
                        Dates.Min(packageItem.EndDate, paidItems.First().ToDate));

                    // if package item date range moved into future, its start date can be greater than last invoice date
                    // no payments now needed for new range, but we still need to refund already paid.
                    // So set quantity and current cost to 0 and let the rest of logic flow.
                    var quantity = Math.Max(currentRange.WeeksInclusive, 0);

                    var currentCost = calculateCurrentCost(currentRange, quantity).Round(2);
                    var refundAmount = CalculateRefundAmount(packageItem, currentCost, paidItems.ToList()).Round(2);

                    if (refundAmount != 0.0m)
                    {
                        yield return new Refund
                        {
                            StartDate = paidItems.First().FromDate,
                            EndDate = paidItems.First().ToDate,
                            Quantity = quantity,
                            Amount = refundAmount
                        };
                    }
                }
            }
        }

        private static Refund TryRefundBeforeFirstPaidDate(
            IPackageItem packageItem, List<InvoiceItem> paidInvoiceItems,
            Func<DateRange, decimal, decimal> calculateCurrentCost)
        {
            var unpaidRange = new DateRange(
                Dates.Max(packageItem.StartDate, PayrunConstants.DefaultStartDate),
                paidInvoiceItems.Min(item => item.FromDate).AddDays(-1));

            if (unpaidRange.WeeksInclusive <= 0) return null;

            // package item start date has been shifted before previously paid invoices - create adjustment for this unpaid period
            // ............[--inv1--][--inv2--]
            // ..[--ref0--][--ref1--][--ref2--]
            var currentCost = calculateCurrentCost(unpaidRange, unpaidRange.WeeksInclusive);

            return new Refund
            {
                StartDate = unpaidRange.StartDate,
                EndDate = unpaidRange.EndDate,
                Quantity = unpaidRange.WeeksInclusive,
                Amount = currentCost.Round(2)
            };
        }

        private static decimal CalculateRefundAmount(IPackageItem packageItem, decimal currentCost, IList<InvoiceItem> paidInvoiceItems)
        {
            switch (packageItem)
            {
                case CarePackageDetail _:
                    return CalculateDetailRefundAmount(currentCost, paidInvoiceItems);

                case CarePackageReclaim reclaim:
                    return CalculateReclaimRefundAmount(reclaim, currentCost, paidInvoiceItems);

                default:
                    throw new InvalidOperationException($"Unsupported IPackageItem {packageItem.GetType()}");
            }
        }

        private static decimal CalculateDetailRefundAmount(decimal currentCost, IList<InvoiceItem> paidInvoiceItems)
        {
            return currentCost - paidInvoiceItems.Sum(item => item.TotalCost);
        }

        private static decimal CalculateReclaimRefundAmount(CarePackageReclaim reclaim, decimal currentCost, IList<InvoiceItem> paidInvoiceItems)
        {
            if (reclaim.ClaimCollector is ClaimCollector.Hackney || reclaim.Status is ReclaimStatus.Cancelled)
            {
                currentCost = 0.0m; // shouldn't pay anything in this case, just refund previous payments
            }

            if (reclaim.SubType is ReclaimSubType.FncPayment)
            {
                return currentCost - paidInvoiceItems.Sum(item => item.TotalCost);
            }

            // total amount deducted from supplier for a given period
            var deductedNetCost = paidInvoiceItems
                .Where(item => item.ClaimCollector is ClaimCollector.Supplier)
                .Sum(item => item.TotalCost);

            // total amount of refunds to/from supplier for a given period
            var refundedCost = paidInvoiceItems
                .Where(item => item.ClaimCollector is null)
                .Sum(item => item.TotalCost);

            // when switching collector from Supplier to Hackney we refund everything not yet refunded,
            // then when staying in Hackney deducted and refunded costs are equal so no refund generated;
            // if initial collector is Hackney, deducted and refunded costs are zero - no refund generated

            return currentCost - refundedCost - deductedNetCost;
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
