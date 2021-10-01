using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetCarePackageUseCase : IGetCarePackageUseCase
    {
        private readonly ICarePackageGateway _carePackageGateway;

        public GetCarePackageUseCase(ICarePackageGateway carePackageGateway)
        {
            _carePackageGateway = carePackageGateway;
        }

        public async Task<IEnumerable<CarePackageResponse>> GetAllAsync()
        {
            var packages = await _carePackageGateway.GetAllPackagesAsync();
            return packages.ToResponse();
        }
    }
}
