using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces
{
    public interface IGetSubmittedPackageRequestsUseCase
    {
        Task<PagedSubmittedPackageRequestsResponse> GetSubmittedPackageRequests(SubmittedPackageRequestParameters parameters);
    }
}
