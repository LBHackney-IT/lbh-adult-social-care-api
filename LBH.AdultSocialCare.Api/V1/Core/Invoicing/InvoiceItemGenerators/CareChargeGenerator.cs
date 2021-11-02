using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using PriceEffect = LBH.AdultSocialCare.Api.V1.AppConstants.PriceEffect;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public class CareChargeGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItemForCreationRequest> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();

            var careCharges = package.Reclaims
                .Where(r => r.Type is ReclaimType.CareCharge)
                .ToList();

            foreach (var careCharge in careCharges)
            {
                if (careCharge.Status != ReclaimStatus.Active) continue;

                var actualStartDate = Dates.Max(careCharge.StartDate, invoiceStartDate);
                var actualEndDate = Dates.Min(careCharge.EndDate, invoiceEndDate);
                var actualWeeks = (actualEndDate.Date - actualStartDate.Date).Days / 7M;

                if (actualWeeks <= 0) continue;

                invoiceItems.Add(new InvoiceItemForCreationRequest
                {
                    ItemName = careCharge.Description ?? careCharge.SubType.GetDisplayName(),
                    PricePerUnit = careCharge.Cost,
                    Quantity = actualWeeks,
                    PriceEffect = careCharge.ClaimCollector switch
                    {
                        ClaimCollector.Hackney => PriceEffect.None,
                        ClaimCollector.Supplier => PriceEffect.Subtract,
                        _ => throw new InvalidOperationException("Unknown claim collector Id")
                    },
                    ClaimedBy = careCharge.ClaimCollector.GetDisplayName()
                });

                // TODO: VK: Add PaidUpTo / PreviousPaidUpTo
                // reclaim.PreviousPaidUpTo = reclaim.PaidUpTo;
                // reclaim.PaidUpTo = Dates.Min(invoiceEndDate, reclaim.PaidUpTo);
            }

            return invoiceItems;
        }
    }
}
