using System;
using System.Collections.Generic;
using System.Linq;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public class CoreCostGenerator : BaseInvoiceItemsGenerator
    {
        private readonly string _coreCostName;

        public CoreCostGenerator(string coreCostName)
        {
            _coreCostName = coreCostName;
        }

        public override IEnumerable<InvoiceItemForCreationRequest> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var coreCost = package.Details.First(d => d.Type is PackageDetailType.CoreCost);

            return new List<InvoiceItemForCreationRequest>
            {
                new InvoiceItemForCreationRequest
                {
                    ItemName = $"{_coreCostName} {invoiceStartDate:dd MMM yyyy} - {invoiceEndDate:dd MMM yyyy}",
                    PricePerUnit = coreCost.Cost,
                    Quantity = Dates.WeeksBetween(invoiceStartDate, invoiceEndDate),
                    PriceEffect = "Add"
                }
            };
        }
    }
}
