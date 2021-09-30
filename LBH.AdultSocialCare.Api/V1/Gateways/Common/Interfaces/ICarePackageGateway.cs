using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageGateway
    {
        Task<CarePackage> GetPackageAsync(Guid packageId);

        Task<CarePackage> GetPackagePlainAsync(Guid packageId, bool trackChanges = false);

        Task<IEnumerable<CarePackageDomain>> GetAllPackagesAsync();

        void Create(CarePackage newCarePackage);
    }
}
