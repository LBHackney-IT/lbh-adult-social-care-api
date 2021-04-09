using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways
{
    public interface IDayCarePackageGateway
    {
        Task<Guid> CreateDayCarePackage(Infrastructure.Entities.DayCarePackage dayCarePackage);

        Task<DayCarePackageDomain> GetDayCarePackage(Guid dayCarePackageId);

        Task<IEnumerable<DayCarePackageDomain>> GetDayCarePackageList();
    }
}
