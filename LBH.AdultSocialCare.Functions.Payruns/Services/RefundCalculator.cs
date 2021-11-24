using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
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

                var paidTotal = existingInvoiceItems.Sum(item => item.TotalCost);
                var newTotal = paymentPeriod is PaymentPeriod.OneOff
                    ? packageItem.Cost
                    : packageItem.Cost * quantity;

                var refundAmount = newTotal - paidTotal;

                return new RefundInfo
                {
                    StartDate = refundStartDate,
                    EndDate = refundEndDate,
                    Quantity = quantity,
                    CurrentCost = newTotal,
                    RefundAmount = refundAmount
                };
            }

            return RefundInfo.Empty;
        }
    }
}
