using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces
{
    public interface IGetAllPackageStatusUseCase
    {
        Task<IEnumerable<StatusResponse>> GetAllAsync();
    }
}
