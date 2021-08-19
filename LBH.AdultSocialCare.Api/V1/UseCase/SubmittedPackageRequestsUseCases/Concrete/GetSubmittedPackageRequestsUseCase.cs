using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.SubmittedPackageRequestsGateways;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Concrete
{
    public class GetSubmittedPackageRequestsUseCase : IGetSubmittedPackageRequestsUseCase
    {
        private readonly ISubmittedPackageRequestsGateway _submittedPackageRequestsGateway;

        public GetSubmittedPackageRequestsUseCase(ISubmittedPackageRequestsGateway submittedPackageRequestsGateway)
        {
            _submittedPackageRequestsGateway = submittedPackageRequestsGateway;
        }

        public async Task<PagedSubmittedPackageRequestsResponse> GetSubmittedPackageRequests(SubmittedPackageRequestParameters parameters)
        {
            var result = await _submittedPackageRequestsGateway.GetSubmittedPackageRequests(parameters).ConfigureAwait(false);
            return new PagedSubmittedPackageRequestsResponse
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
