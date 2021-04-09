using BaseApi.V1.Domain.DayCarePackageDomains;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways.DayCarePackageGateways
{
    public interface IDayCarePackageGateway
    {
        Task<Guid> CreateDayCarePackage(Infrastructure.Entities.DayCarePackage dayCarePackage);

        Task<DayCarePackageDomain> GetDayCarePackage(Guid dayCarePackageId);

        Task<IEnumerable<DayCarePackageDomain>> GetDayCarePackageList();
    }
}
