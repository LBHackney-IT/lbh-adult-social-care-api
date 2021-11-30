using System;
using System.Collections.Generic;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class CarePackageDetailGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> CreateNormalItems(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            foreach (var detail in package.Details)
            {
                var itemRange = GetInvoiceItemDateRange(detail, packageInvoices, invoiceEndDate);
                if (itemRange.Weeks <= 0) continue;

                yield return new InvoiceItem
                {
                    Name = GetItemName(detail),
                    Quantity = itemRange.Weeks,
                    WeeklyCost = detail.CostPeriod is PaymentPeriod.OneOff
                        ? 0.0m
                        : detail.Cost,
                    TotalCost = detail.CostPeriod is PaymentPeriod.OneOff
                        ? detail.Cost
                        : detail.Cost * itemRange.Weeks,
                    FromDate = itemRange.StartDate,
                    ToDate = itemRange.EndDate,
                    CarePackageDetailId = detail.Id,
                    SourceVersion = detail.Version,
                    PriceEffect = PriceEffect.Add
                };
            }
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
                    yield return new InvoiceItem
                    {
                        Name = $"{GetItemName(detail)} (refund)",
                        Quantity = refund.Quantity,
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
