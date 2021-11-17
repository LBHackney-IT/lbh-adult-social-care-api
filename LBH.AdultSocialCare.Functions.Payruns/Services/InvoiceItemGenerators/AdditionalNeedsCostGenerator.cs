using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class AdditionalNeedsCostGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItem>();
            var additionalNeeds = package.Details.Where(d => d.Type is PackageDetailType.AdditionalNeed);

            foreach (var additionalNeed in additionalNeeds)
            {
                var actualStartDate = Dates.Max(additionalNeed.StartDate, invoiceStartDate);
                var actualEndDate = Dates.Min(additionalNeed.EndDate, invoiceEndDate);
                var actualWeeks = (actualEndDate.Date - actualStartDate.Date).Days / 7M;

                if (actualWeeks <= 0) continue;

                var invoiceItem = new InvoiceItem
                {
                    Name = $"Additional {additionalNeed.CostPeriod.GetDisplayName()} Cost",
                    Quantity = actualWeeks,
                    WeeklyCost = additionalNeed.Cost,           // TODO: VK: Consider making WeeklyCost nullable for one-offs
                    TotalCost =  additionalNeed.CostPeriod is PaymentPeriod.OneOff
                        ? additionalNeed.Cost
                        : additionalNeed.Cost * actualWeeks,
                    FromDate = actualStartDate,
                    ToDate = actualEndDate,
                    ClaimCollector = ClaimCollector.Hackney,    // TODO: VK: Make ClaimCollector nullable
                    PriceEffect = PriceEffect.Add,              // TODO: VK: Review
                    IsReclaim = false                           // TODO: VK: Remove
                };

                invoiceItems.Add(invoiceItem);
            }

            return invoiceItems;
        }
    }
}
