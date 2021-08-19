using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces
{
    public interface IGetAllPackageStatusUseCase
    {
        Task<IEnumerable<StatusResponse>> GetAllAsync();
    }
}
