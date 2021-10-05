using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetApprovedPackagesUseCase : IGetApprovedPackagesUseCase
    {
        private readonly IApprovedPackagesGateway _approvedPackagesGateway;

        public GetApprovedPackagesUseCase(IApprovedPackagesGateway approvedPackagesGateway)
        {
            _approvedPackagesGateway = approvedPackagesGateway;
        }

        public async Task<PagedApprovedPackagesResponse> GetApprovedPackages(ApprovedPackagesParameters parameters, int statusId)
        {
            var result = await _approvedPackagesGateway.GetApprovedPackages(parameters, statusId).ConfigureAwait(false);
            return new PagedApprovedPackagesResponse()
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
