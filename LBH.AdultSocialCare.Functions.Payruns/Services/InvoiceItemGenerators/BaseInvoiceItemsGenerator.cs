using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Services.InvoiceItemGenerators
{
    public abstract class BaseInvoiceItemsGenerator
    {
        /// <summary>
        /// This method is called for each package in invoicing period, so generator can produce invoice items for single package
        /// </summary>
        public abstract IEnumerable<InvoiceItem> Run(CarePackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate);

        /// <summary>
        /// This method is called right before invoice generation process is started, so generator can initialize its internal state
        /// </summary>
        public virtual Task Initialize()
        {
            return Task.CompletedTask;
        }
    }
}
