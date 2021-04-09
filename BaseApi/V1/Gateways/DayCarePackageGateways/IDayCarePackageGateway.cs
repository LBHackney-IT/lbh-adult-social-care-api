using System;
using System.Threading.Tasks;
using BaseApi.V1.Domain.DayCarePackageDomains;

namespace BaseApi.V1.Gateways.DayCarePackageGateways
{
    public interface IDayCarePackageGateway
    {
        Task<Guid> CreateDayCarePackage(Infrastructure.Entities.DayCarePackage dayCarePackage);

        Task<DayCarePackageDomain> GetDayCarePackage(Guid dayCarePackageId);
    }
}
