using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Core.Invoicing.InvoiceItemGenerators
{
    public abstract class BaseInvoiceItemsGenerator
    {
        /// <summary>
        /// This method is called for each package in invoicing period, so generator can produce invoice items for single package
        /// </summary>
        public abstract IEnumerable<InvoiceItemForCreationRequest> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate);

        /// <summary>
        /// This method is called right before invoice generation process is started, so generator can initialize its internal state
        /// </summary>
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}
