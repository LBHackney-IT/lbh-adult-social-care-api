using System;
using System.Collections.Generic;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;

namespace LBH.AdultSocialCare.Api.V1.BusinessRules.Invoicing.Generators
{
    public interface IInvoiceItemsGenerator
    {
        IEnumerable<InvoiceItemForCreationRequest> Run(GenericPackage package, DateTimeOffset invoiceStartDate, DateTimeOffset invoiceEndDate);
    }
}
