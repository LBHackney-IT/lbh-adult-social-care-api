using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface IGetDayCarePackageUseCase
    {
        Task<DayCarePackageResponse> Execute(Guid dayCarePackageId);
    }
}
