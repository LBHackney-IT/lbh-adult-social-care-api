using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;

namespace LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing.Generators
{
    public interface IInvoiceItemsGenerator
    {
        /// <summary>
        /// This method is called for each package in invoicing period, so generator can produce invoice items for single package
        /// </summary>
        IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate);

        /// <summary>
        /// This method is called after entire invoice for packages is generated, so generator can save its specific state
        /// accumulated during invoice items calcultaions
        /// </summary>
        public Task OnInvoiceBatchGenerated(DateTimeOffset invoiceEndDate)
        {
            return Task.CompletedTask;
        }
    }
}
