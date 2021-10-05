using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
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
