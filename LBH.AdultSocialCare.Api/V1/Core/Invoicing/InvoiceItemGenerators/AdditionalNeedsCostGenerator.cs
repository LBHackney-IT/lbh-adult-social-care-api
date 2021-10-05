using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public class AdditionalNeedsCostGenerator : BaseInvoiceItemsGenerator
    {
        public override IEnumerable<InvoiceItemForCreationRequest> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();
            var additionalNeeds = package.Details.Where(d => d.Type is PackageDetailType.AdditionalNeed);

            foreach (var additionalNeed in additionalNeeds)
            {
                var invoiceItem = new InvoiceItemForCreationRequest
                {
                    ItemName =
                        $"Additional Needs {additionalNeed.CostPeriod.GetDisplayName()} {invoiceStartDate:dd MMM yyyy} - {invoiceEndDate:dd MMM yyyy}",
                    PricePerUnit = additionalNeed.Cost,
                    PriceEffect = "Add"
                };

                // create invoice item for additional needs item except one off cost
                if (additionalNeed.CostPeriod != PaymentPeriod.OneOff)
                {
                    invoiceItem.Quantity = Dates.WeeksBetween(invoiceStartDate, invoiceEndDate);
                }
                // TODO: VK: Add PaidUpTo fields - package or core cost
                // else if (package.PaidUpTo is null)
                // {
                //     invoiceItem.Quantity = 1;
                // }

                invoiceItems.Add(invoiceItem);
            }

            return invoiceItems;
        }
    }
}
