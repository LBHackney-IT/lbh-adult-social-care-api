using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public class AdditionalNeedsCostGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> Run(CarePackage package, IList<Invoice> packageInvoices, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItem>();
            var additionalNeeds = package.Details.Where(d => d.Type is PackageDetailType.AdditionalNeed);

            foreach (var additionalNeed in additionalNeeds)
            {
                var itemRange = GetInvoiceItemDateRange(additionalNeed, packageInvoices, invoiceEndDate);
                if (itemRange.Weeks <= 0) continue;

                var invoiceItem = new InvoiceItem
                {
                    Name = $"Additional {additionalNeed.CostPeriod.GetDisplayName()} Cost",
                    Quantity = itemRange.Weeks,
                    WeeklyCost = additionalNeed.Cost,           // TODO: VK: Consider making WeeklyCost nullable for one-offs
                    TotalCost = additionalNeed.CostPeriod is PaymentPeriod.OneOff
                        ? additionalNeed.Cost
                        : additionalNeed.Cost * itemRange.Weeks,
                    FromDate = itemRange.StartDate,
                    ToDate = itemRange.EndDate,
                    CarePackageDetailId = additionalNeed.Id,
                    ClaimCollector = ClaimCollector.Hackney,
                    PriceEffect = PriceEffect.Add              // TODO: VK: Review
                };

                invoiceItems.Add(invoiceItem);
            }

            return invoiceItems;
        }
    }
}
