using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public abstract class BaseInvoiceItemsGenerator
    {
        /// <summary>
        /// This method is called for each package in invoicing period, so generator can produce invoice items for single package
        /// </summary>
        public abstract IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate);

        /// <summary>
        /// This method is called right before invoice generation process is started, so generator can initialize its internal state
        /// </summary>
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// This method is called after invoices for batch of packages are generated, so generator can save its specific state
        /// accumulated during invoice items calculations
        /// </summary>
        public virtual Task OnInvoiceBatchGenerated(DateTimeOffset invoiceEndDate)
        {
            return Task.CompletedTask;
        }
    }
}
