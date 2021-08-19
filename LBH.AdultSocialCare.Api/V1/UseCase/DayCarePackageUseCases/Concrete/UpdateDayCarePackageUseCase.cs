using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class UpdateDayCarePackageUseCase : IUpdateDayCarePackageUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;

        public UpdateDayCarePackageUseCase(IDayCarePackageGateway dayCarePackageGateway)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
        }

        public async Task<DayCarePackageResponse> Execute(Guid dayCarePackageId, DayCarePackageForUpdateDomain dayCarePackageForUpdateDomain)
        {
            dayCarePackageForUpdateDomain.DayCarePackageId = dayCarePackageId;
            var result = await _dayCarePackageGateway.UpdateDayCarePackage(dayCarePackageForUpdateDomain).ConfigureAwait(false);
            return result.ToResponse();
        }
    }
}
