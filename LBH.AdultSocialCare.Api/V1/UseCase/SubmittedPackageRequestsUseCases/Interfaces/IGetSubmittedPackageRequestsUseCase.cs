using LBH.AdultSocialCare.Api.V1.Boundary.SubmittedPackageRequestsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces
{
    public interface IGetSubmittedPackageRequestsUseCase
    {
        Task<PagedSubmittedPackageRequestsResponse> GetSubmittedPackageRequests(SubmittedPackageRequestParameters parameters);
    }
}
