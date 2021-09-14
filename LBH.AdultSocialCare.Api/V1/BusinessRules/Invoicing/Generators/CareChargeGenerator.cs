using System;
using System.Collections.Generic;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;

namespace LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing.Generators
{
    public class CareChargeGenerator : IInvoiceItemsGenerator
    {
        public IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();

            if (package.CareCharge is null) return invoiceItems;

            foreach (var element in package.CareCharge.CareChargeElements)
            {
                var actualStartDate = Dates.Max(element.StartDate, invoiceEndDate);
                var actualEndDate = Dates.Min(element.EndDate, invoiceStartDate);

                var actualWeeks = (actualEndDate.Date - actualStartDate.Date).Days / 7M;

                invoiceItems.Add(new InvoiceItemForCreationRequest
                {
                    ItemName = element.Name ?? element.CareChargeType.OptionName,
                    PricePerUnit = element.Amount,
                    Quantity = actualWeeks,
                    PriceEffect = "USE REAL PRICE EFFECT",
                    ClaimedBy = element.ClaimCollector.Name
                });
            }

            return invoiceItems;
        }
    }
}
