using BaseApi.V1.Domain.DayCarePackageDomains;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.DayCarePackageGateways;
using BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.DayCarePackageUseCases.Concrete
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
