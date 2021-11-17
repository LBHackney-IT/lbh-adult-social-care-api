using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces
{
    public interface ICarePackageGateway : IGateway
    {
        Task<IList<Guid>> GetUnpaidPackageIdsAsync(DateTimeOffset startDate, DateTimeOffset endDate);

        Task<IList<CarePackage>> GetListAsync(IList<Guid> ids);

        Task<int> GetInvoicesCountAsync(); // TODO: VK: Remove
    }
}
