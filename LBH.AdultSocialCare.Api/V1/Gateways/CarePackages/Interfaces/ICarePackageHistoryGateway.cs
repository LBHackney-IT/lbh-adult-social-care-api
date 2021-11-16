using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces
{
    public interface ICarePackageHistoryGateway
    {
        Task<IEnumerable<CarePackageHistoryDomain>> ListAsync(Guid carePackageId);

        Task Create(CarePackageHistory newCarePackageHistory);
    }
}
