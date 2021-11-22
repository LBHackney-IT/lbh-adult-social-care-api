using System;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class CoreCostGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> Run(CarePackage package, IList<Invoice> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var coreCost = package.Details.First(d => d.Type is PackageDetailType.CoreCost);
            var itemRange = GetInvoiceItemDateRange(coreCost, packageInvoices, invoiceEndDate);

            if (itemRange.Weeks <= 0) return new List<InvoiceItem>();

            return new List<InvoiceItem>
            {
                new InvoiceItem
                {
                    Name = package.PackageType switch
                    {
                        PackageType.NursingCare => "Nursing Care Core",
                        PackageType.ResidentialCare => "Residential Care Core",
                        _ => "Unknown"
                    },
                    Quantity = itemRange.Weeks,
                    WeeklyCost = coreCost.Cost,
                    TotalCost = itemRange.Weeks * coreCost.Cost,
                    FromDate = itemRange.StartDate,
                    ToDate = itemRange.EndDate,
                    CarePackageDetailId = coreCost.Id,
                    SourceVersion = coreCost.Version,
                    PriceEffect = PriceEffect.Add               // TODO: VK: Review
                }
            };
        }
    }
}
