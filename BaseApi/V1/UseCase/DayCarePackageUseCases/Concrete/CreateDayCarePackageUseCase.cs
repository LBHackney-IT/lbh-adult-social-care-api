using System;
using System.Threading.Tasks;
using BaseApi.V1.Gateways.DayCarePackageGateways;
using BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces;

namespace BaseApi.V1.UseCase.DayCarePackageUseCases.Concrete
{
    public class CreateDayCarePackageUseCase : ICreateDayCarePackageUseCase
    {
        private readonly IDayCarePackageGateway _dayCarePackageGateway;

        public CreateDayCarePackageUseCase(IDayCarePackageGateway dayCarePackageGateway)
        {
            _dayCarePackageGateway = dayCarePackageGateway;
        }
        public async Task<Guid> Execute(Infrastructure.Entities.DayCarePackage dayCarePackage)
        {
            var id = await _dayCarePackageGateway.CreateDayCarePackage(dayCarePackage).ConfigureAwait(false);
            return id;
        }
    }
}
