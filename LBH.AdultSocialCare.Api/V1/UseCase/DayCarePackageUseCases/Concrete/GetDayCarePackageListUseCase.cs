using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class GetDayCarePackageListUseCase : IGetDayCarePackageListUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;

        public GetDayCarePackageListUseCase(IDayCarePackageGateway dayCarePackageGateway)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
        }

        public async Task<IEnumerable<DayCarePackageResponse>> Execute()
        {
            var dayCarePackages = await _dayCarePackageGateway.GetDayCarePackageList().ConfigureAwait(false);
            return dayCarePackages.ToResponse();
        }
    }
}
