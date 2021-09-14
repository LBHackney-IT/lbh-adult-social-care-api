using System;
using System.Collections.Generic;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants;

namespace LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing.Generators
{
    public class AdditionalNeedsCostGenerator : IInvoiceItemsGenerator
    {
        public IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate)
        {
            var invoiceItems = new List<InvoiceItemForCreationRequest>();

            if (package.BrokerageInfo.AdditionalNeedsCosts is null) return invoiceItems;

            foreach (var cost in package.BrokerageInfo.AdditionalNeedsCosts)
            {
                var invoiceItem = new InvoiceItemForCreationRequest
                {
                    ItemName =
                        $"Additional Needs {cost.AdditionalNeedsPaymentType.OptionName} {invoiceStartDate:dd MMM yyyy} - {invoiceEndDate:dd MMM yyyy}",
                    PricePerUnit = cost.Cost,
                    PriceEffect = "Add"
                };

                // create invoice item for additional needs item except one off cost
                if (cost.AdditionalNeedsPaymentType.AdditionalNeedsPaymentTypeId != AdditionalNeedPaymentTypesConstants.OneOff)
                {
                    invoiceItem.Quantity = Dates.WeeksBetween(invoiceStartDate, invoiceEndDate);
                }
                else if (package.PaidUpTo is null)
                {
                    invoiceItem.Quantity = 1;
                }

                invoiceItems.Add(invoiceItem);
            }

            return invoiceItems;
        }
    }
}
