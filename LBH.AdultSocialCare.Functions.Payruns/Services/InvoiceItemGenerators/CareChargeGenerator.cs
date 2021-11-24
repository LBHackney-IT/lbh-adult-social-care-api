using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class CareChargeGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> CreateNormalItem(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItem>();

            var careCharges = package.Reclaims
                .Where(r => r.Type is ReclaimType.CareCharge &&
                            r.Status is ReclaimStatus.Active)
                .ToList();

            foreach (var careCharge in careCharges)
            {
                if (careCharge.Status != ReclaimStatus.Active) continue;

                var itemRange = GetInvoiceItemDateRange(careCharge, packageInvoices, invoiceEndDate);
                if (itemRange.Weeks <= 0) continue;

                invoiceItems.Add(new InvoiceItem
                {
                    Name = $"Care Charge {careCharge.SubType.GetDisplayName()}",
                    Quantity = itemRange.Weeks,
                    WeeklyCost = careCharge.Cost,
                    TotalCost = careCharge.Cost * itemRange.Weeks,
                    FromDate = itemRange.StartDate,
                    ToDate = itemRange.EndDate,
                    CarePackageReclaimId = careCharge.Id,
                    ClaimCollector = careCharge.ClaimCollector,
                    SourceVersion = careCharge.Version,
                    PriceEffect = careCharge.ClaimCollector switch
                    {
                        ClaimCollector.Hackney => PriceEffect.None,
                        ClaimCollector.Supplier => PriceEffect.Subtract,
                        _ => throw new InvalidOperationException("Unknown claim collector")
                    }
                });
            }

            return invoiceItems;
        }

        public override IEnumerable<InvoiceItem> CreateRefundItem(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            var careCharges = package.Reclaims
                .Where(r => r.Type is ReclaimType.CareCharge &&
                            r.Status is ReclaimStatus.Active)
                .ToList();

            foreach (var careCharge in careCharges)
            {
                var refund = RefundCalculator.Calculate(careCharge, packageInvoices, PaymentPeriod.Weekly);

                if (refund.RefundAmount == 0.0m) continue;

                yield return new InvoiceItem
                {
                    Name = $"Care Charge {careCharge.SubType.GetDisplayName()} (refund)",
                    Quantity = refund.Quantity,
                    WeeklyCost = careCharge.Cost,
                    TotalCost = refund.RefundAmount,
                    FromDate = refund.StartDate,
                    ToDate = refund.EndDate,
                    CarePackageReclaimId = careCharge.Id,
                    SourceVersion = careCharge.Version,
                    NetCostsCompensated = refund.NetCostsCompensated,
                    PriceEffect = refund.RefundAmount > 0
                        ? PriceEffect.Add
                        : PriceEffect.Subtract
                };
            }
        }
    }
}
