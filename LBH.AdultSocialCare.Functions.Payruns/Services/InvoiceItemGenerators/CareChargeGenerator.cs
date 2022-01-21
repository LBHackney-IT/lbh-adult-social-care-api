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
        public override IEnumerable<InvoiceItem> CreateNormalItems(CarePackage package, IList<InvoiceDomain> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var careCharges = package.Reclaims
                .Where(reclaim =>
                    reclaim.Type is ReclaimType.CareCharge &&
                    reclaim.ClaimCollector is ClaimCollector.Supplier &&
                    reclaim.Status != ReclaimStatus.Cancelled &&
                    reclaim.StartDate <= invoiceEndDate)
                .ToList();

            foreach (var careCharge in careCharges)
            {
                var itemRange = GetInvoiceItemDateRange(careCharge, packageInvoices, invoiceEndDate);
                if (itemRange.WeeksInclusive <= 0) continue;

                yield return new InvoiceItem
                {
                    Name = $"Care Charge {careCharge.SubType.GetDisplayName()}",
                    Quantity = itemRange.WeeksInclusive,
                    WeeklyCost = Decimal.Negate(careCharge.Cost),
                    TotalCost = Decimal.Negate((careCharge.Cost * itemRange.WeeksInclusive).Round(2)),
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
                };
            }
        }

        public override IEnumerable<InvoiceItem> CreateRefundItems(CarePackage package, IList<InvoiceDomain> packageInvoices)
        {
            var careCharges = package.Reclaims
                .Where(r => r.Type is ReclaimType.CareCharge)
                .ToList();

            foreach (var careCharge in careCharges)
            {
                var refunds = RefundCalculator.Calculate(
                    careCharge, packageInvoices,
                    (paymentRange, quantity) => Decimal.Negate(careCharge.Cost * quantity));

                foreach (var refund in refunds)
                {
                    yield return new InvoiceItem
                    {
                        Name = $"Care Charge {careCharge.SubType.GetDisplayName()} (adjustment)",
                        Quantity = refund.Quantity,
                        WeeklyCost = careCharge.Cost,
                        TotalCost = refund.Amount,
                        FromDate = refund.StartDate,
                        ToDate = refund.EndDate,
                        CarePackageReclaimId = careCharge.Id,
                        SourceVersion = careCharge.Version,
                        PriceEffect = refund.Amount > 0
                            ? PriceEffect.Add
                            : PriceEffect.Subtract
                    };
                }
            }
        }
    }
}
