using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Concrete
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
