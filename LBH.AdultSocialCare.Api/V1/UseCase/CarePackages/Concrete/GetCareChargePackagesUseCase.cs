using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class GetCareChargePackagesUseCase : IGetCareChargePackagesUseCase
    {
        private readonly ICareChargesGateway _careChargesGateway;

        public GetCareChargePackagesUseCase(ICareChargesGateway careChargesGateway)
        {
            _careChargesGateway = careChargesGateway;
        }

        public async Task<PagedResponse<CareChargePackagesResponse>> GetCareChargePackages(CareChargePackagesParameters parameters)
        {
            var result = await _careChargesGateway.GetCareChargePackages(parameters).ConfigureAwait(false);

            return new PagedResponse<CareChargePackagesResponse>
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
