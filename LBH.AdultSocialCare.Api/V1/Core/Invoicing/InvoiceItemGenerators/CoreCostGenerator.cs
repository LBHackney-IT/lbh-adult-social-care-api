using System;
using System.Collections.Generic;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public class CoreCostGenerator : BaseInvoiceItemsGenerator
    {
        private readonly string _coreCostName;

        public CoreCostGenerator(string coreCostName)
        {
            _coreCostName = coreCostName;
        }

        public override IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            return new List<InvoiceItemForCreationRequest>
            {
                new InvoiceItemForCreationRequest
                {
                    ItemName = $"{_coreCostName} {invoiceStartDate:dd MMM yyyy} - {invoiceEndDate:dd MMM yyyy}",
                    PricePerUnit = package.BrokerageInfo.Core,
                    Quantity = Dates.WeeksBetween(invoiceStartDate, invoiceEndDate),
                    PriceEffect = "Add"
                }
            };
        }
    }
}
