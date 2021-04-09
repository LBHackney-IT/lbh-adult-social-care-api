using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class CreateDayCarePackageUseCase : ICreateDayCarePackageUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;

        public CreateDayCarePackageUseCase(IDayCarePackageGateway dayCarePackageGateway)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
        }

        public async Task<Guid> Execute(DayCarePackageForCreationDomain dayCarePackageForCreationDomain)
        {
            var dayCarePackageEntity = dayCarePackageForCreationDomain.ToDb();
            var id = await _dayCarePackageGateway.CreateDayCarePackage(dayCarePackageEntity).ConfigureAwait(false);
            return id;
        }
    }
}
