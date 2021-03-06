using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Payments;
using LBH.AdultSocialCare.Functions.Payruns.Domain;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces
{
    public interface IInvoiceGateway : IGateway
    {
        Task<Dictionary<Guid, List<InvoiceDomain>>> GetInvoicesByPackageIds(IList<Guid> packageIds);

        Task<long> GetInvoicesCountAsync();

        void RejectInvoices(IEnumerable<PayrunInvoice> payrunInvoices);

        Task AcceptReleasedInvoices(IList<Guid> packageIds);
    }
}
