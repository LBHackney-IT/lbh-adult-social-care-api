using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface IGetDayCarePackageListUseCase
    {
        Task<IEnumerable<DayCarePackageResponse>> Execute();
    }
}