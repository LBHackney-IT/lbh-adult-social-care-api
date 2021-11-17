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
    public class CareChargeGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItem> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItem>();

            var careCharges = package.Reclaims
                .Where(r => r.Type is ReclaimType.CareCharge &&
                            r.Status is ReclaimStatus.Active)
                .ToList();

            foreach (var careCharge in careCharges)
            {
                if (careCharge.Status != ReclaimStatus.Active) continue;

                var actualStartDate = Dates.Max(careCharge.StartDate, invoiceStartDate);
                var actualEndDate = Dates.Min(careCharge.EndDate, invoiceEndDate);
                var actualWeeks = (actualEndDate.Date - actualStartDate.Date).Days / 7M;

                if (actualWeeks <= 0) continue;

                invoiceItems.Add(new InvoiceItem
                {
                    Name = $"Care Charge {careCharge.SubType.GetDisplayName()}",
                    Quantity = actualWeeks,
                    WeeklyCost = careCharge.Cost,
                    TotalCost = careCharge.Cost * actualWeeks,
                    FromDate = actualStartDate,
                    ToDate = actualEndDate,
                    ClaimCollector = careCharge.ClaimCollector,
                    PriceEffect = careCharge.ClaimCollector switch
                    {
                        ClaimCollector.Hackney => PriceEffect.None,
                        ClaimCollector.Supplier => PriceEffect.Subtract,
                        _ => throw new InvalidOperationException("Unknown claim collector")
                    },
                    IsReclaim = true
                });
            }

            return invoiceItems;
        }
    }
}
