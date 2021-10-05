using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetCareChargePackagesUseCase : IGetCareChargePackagesUseCase
    {
        private readonly ICarePackageReclaimGateway _carePackageReclaimGateway;

        public GetCareChargePackagesUseCase(ICarePackageReclaimGateway carePackageReclaimGateway)
        {
            _carePackageReclaimGateway = carePackageReclaimGateway;
        }

        public async Task<PagedCareChargePackagesResponse> GetCareChargePackages(CareChargePackagesParameters parameters)
        {
            var result = await _carePackageReclaimGateway.GetCareChargePackages(parameters).ConfigureAwait(false);
            return new PagedCareChargePackagesResponse()
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
