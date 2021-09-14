using System;
using System.Collections.Generic;
using HttpServices.Models.Requests;

namespace LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing.Generators
{
    public interface IInvoiceItemsGenerator
    {
        IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate);
    }
}
