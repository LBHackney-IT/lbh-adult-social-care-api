using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface IGetDayCarePackageListUseCase
    {
        Task<IEnumerable<DayCarePackageResponse>> Execute();
    }
}
