using BaseApi.V1.Boundary.DayCarePackageBoundary.Response;
using BaseApi.V1.UseCase.DayCarePackageUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.Model;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.DayCarePackageGateways;

namespace BaseApi.V1.UseCase.DayCarePackageUseCases.Concrete
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
