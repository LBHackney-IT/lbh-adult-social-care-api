using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;
using LBH.AdultSocialCare.Functions.Payruns.Extensions;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class CarePackageDetailGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> CreateNormalItems(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            foreach (var detail in package.Details)
            {
                var item = detail.CostPeriod is PaymentPeriod.OneOff
                    ? CreateOneOffItem(detail, packageInvoices, invoiceEndDate)
                    : CreateWeeklyItem(detail, packageInvoices, invoiceEndDate);

                if (item is null) continue;

                yield return item;
            }
        }

        private static InvoiceItem CreateOneOffItem(CarePackageDetail detail, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            // One-off invoice is created just once for entire period, in consequent invoices one-off is ignored
            var oneOffInvoiceItemExists = packageInvoices.Any(invoice =>
                invoice.Status.In(InvoiceStatus.Accepted, InvoiceStatus.Held) &&
                invoice.Items.Any(detail.IsReferenced));

            if (oneOffInvoiceItemExists) return null;

            var startDate = Dates.Max(detail.StartDate, PayrunConstants.DefaultStartDate);
            var endDate = detail.EndDate ?? startDate.AddDays(1); // arbitrary number just to get quantity 1 in UI for ongoing one-off, review

            if (startDate.UtcDateTime > invoiceEndDate.UtcDateTime) return null;

            return new InvoiceItem
            {
                Name = GetItemName(detail),
                Quantity = Dates.WeeksBetween(startDate, endDate),
                WeeklyCost = 0.0m,
                TotalCost = detail.Cost,
                FromDate = startDate,
                ToDate = endDate,
                CarePackageDetailId = detail.Id,
                SourceVersion = detail.Version,
                PriceEffect = PriceEffect.Add
            };
        }

        private static InvoiceItem CreateWeeklyItem(CarePackageDetail detail, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var itemRange = GetInvoiceItemDateRange(detail, packageInvoices, invoiceEndDate);
            if (itemRange.Weeks <= 0) return null;

            return new InvoiceItem
            {
                Name = GetItemName(detail),
                Quantity = itemRange.Weeks,
                WeeklyCost = detail.Cost,
                TotalCost = detail.Cost * itemRange.Weeks,
                FromDate = itemRange.StartDate,
                ToDate = itemRange.EndDate,
                CarePackageDetailId = detail.Id,
                SourceVersion = detail.Version,
                PriceEffect = PriceEffect.Add
            };
        }

        public override IEnumerable<InvoiceItem> CreateRefundItems(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            foreach (var detail in package.Details)
            {
                var refunds = RefundCalculator.Calculate(
                    detail, packageInvoices,
                    (start, end, quantity) => detail.CostPeriod is PaymentPeriod.OneOff
                        ? detail.Cost
                        : detail.Cost * quantity);

                foreach (var refund in refunds)
                {
                    var quantity = refund.Quantity;
                    if (detail.CostPeriod is PaymentPeriod.OneOff)
                    {
                        var startDate = Dates.Max(detail.StartDate, PayrunConstants.DefaultStartDate);
                        var endDate = detail.EndDate ?? startDate.AddDays(1); // arbitrary number just to get quantity 1 in UI for ongoing one-off

                        quantity = Dates.WeeksBetween(startDate, endDate);
                    }

                    yield return new InvoiceItem
                    {
                        Name = $"{GetItemName(detail)} (refund)",
                        Quantity = quantity,
                        WeeklyCost = detail.CostPeriod is PaymentPeriod.OneOff
                            ? 0.0m
                            : detail.Cost,
                        TotalCost = refund.RefundAmount,
                        FromDate = refund.StartDate,
                        ToDate = refund.EndDate,
                        CarePackageDetailId = detail.Id,
                        SourceVersion = detail.Version,
                        PriceEffect = refund.RefundAmount > 0 ? PriceEffect.Add : PriceEffect.Subtract
                    };
                }
            }
        }

        private static string GetItemName(CarePackageDetail detail)
        {
            switch (detail.Type)
            {
                case PackageDetailType.CoreCost:
                    return detail.Package.PackageType switch
                    {
                        PackageType.NursingCare => "Nursing Care Core",
                        PackageType.ResidentialCare => "Residential Care Core",
                        _ => throw new ArgumentException($"Unsupported {detail.Type}")
                    };

                case PackageDetailType.AdditionalNeed:
                    return $"Additional {detail.CostPeriod.GetDisplayName()} Cost";

                default:
                    throw new ArgumentException($"Unsupported {detail.Type}");
            }
        }
    }
}
