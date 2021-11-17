using System;
using System.Collections.Generic;
using System.Linq;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class CoreCostGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var coreCost = package.Details.First(d => d.Type is PackageDetailType.CoreCost);

            var actualStartDate = Dates.Max(coreCost.StartDate, invoiceStartDate);
            var actualEndDate = Dates.Min(coreCost.EndDate, invoiceEndDate);
            var actualWeeks = (actualEndDate.Date - actualStartDate.Date).Days / 7M;

            if (actualWeeks <= 0) return new List<InvoiceItem>();

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
                    Quantity = actualWeeks,
                    WeeklyCost = coreCost.Cost,
                    TotalCost = actualWeeks * coreCost.Cost,
                    FromDate = actualStartDate,
                    ToDate = actualEndDate,
                    ClaimCollector = ClaimCollector.Hackney, // TODO: VK: Make ClaimCollector nullable
                    PriceEffect = PriceEffect.Add,           // TODO: VK: Review
                    IsReclaim = false                        // TODO: VK: Remove
                }
            };
        }
    }
}
