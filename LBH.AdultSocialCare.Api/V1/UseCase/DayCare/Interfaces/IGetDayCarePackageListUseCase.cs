using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces
{
    public interface IGetDayCarePackageListUseCase
    {
        Task<IEnumerable<DayCarePackageResponse>> Execute();
    }
}
