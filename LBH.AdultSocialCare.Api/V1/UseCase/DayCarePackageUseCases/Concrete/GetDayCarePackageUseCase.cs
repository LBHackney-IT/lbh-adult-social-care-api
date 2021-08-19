using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class GetDayCarePackageUseCase : IGetDayCarePackageUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;

        public GetDayCarePackageUseCase(IDayCarePackageGateway dayCarePackageGateway)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
        }

        public async Task<DayCarePackageResponse> Execute(Guid dayCarePackageId)
        {
            var dayCarePackage = await _dayCarePackageGateway.GetDayCarePackage(dayCarePackageId).ConfigureAwait(false);
            return dayCarePackage.ToResponse();
        }
    }
}
