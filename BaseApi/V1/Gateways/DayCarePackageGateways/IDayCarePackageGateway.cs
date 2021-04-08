using System;
using System.Threading.Tasks;
using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;

namespace BaseApi.V1.Gateways.DayCarePackageGateways
{
    public interface IDayCarePackageGateway
    {
        Task<Guid> CreateDayCarePackage(Infrastructure.Entities.DayCarePackage dayCarePackage);
        Task<DayCarePackageResponse> GetDayCarePackage(Guid dayCarePackageId);
        Task SaveChangesAsync();
    }
}
