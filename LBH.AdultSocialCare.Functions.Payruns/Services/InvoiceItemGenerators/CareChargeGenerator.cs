using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class CareChargeGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> Run(CarePackage package, IList<Invoice> packageInvoices, DateTimeOffset invoiceEndDate)
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
    }
}
