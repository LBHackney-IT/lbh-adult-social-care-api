using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces
{
    public interface IInvoiceGateway : IGateway
    {
        Task<Dictionary<Guid, List<Invoice>>> GetInvoicesByPackageIds(IList<Guid> packageIds);

        Task<int> GetInvoicesCountAsync();
    }
}
