using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.DayCarePackageGateways;
using BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.DayCarePackageUseCases.Concrete
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
