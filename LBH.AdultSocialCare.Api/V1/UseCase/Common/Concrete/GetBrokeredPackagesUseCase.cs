using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetBrokeredPackagesUseCase : IGetBrokeredPackagesUseCase
    {
        private readonly IBrokeredPackagesGateway _brokeredPackagesGateway;

        public GetBrokeredPackagesUseCase(IBrokeredPackagesGateway brokeredPackagesGateway)
        {
            _brokeredPackagesGateway = brokeredPackagesGateway;
        }

        public async Task<PagedBrokeredPackagesResponse> GetBrokeredPackages(BrokeredPackagesParameters parameters, int statusId)
        {
            var result = await _brokeredPackagesGateway.GetBrokeredPackages(parameters, statusId).ConfigureAwait(false);
            return new PagedBrokeredPackagesResponse()
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
