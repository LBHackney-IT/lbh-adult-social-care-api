using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces
{
    public interface ICarePackageHistoryGateway
    {
        Task<IEnumerable<CarePackageHistoryDomain>> ListAsync(Guid carePackageId);

        void Create(CarePackageHistory newCarePackageHistory);
    }
}
