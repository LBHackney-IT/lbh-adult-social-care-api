using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class GetPackageUseCase : IGetPackageUseCase
    {
        private readonly IPackageGateway _gateway;
        public GetPackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<PackageDomain> GetAsync(Guid packageId)
        {
            var packageEntity = await _gateway.GetAsync(packageId).ConfigureAwait(false);
            return PackageFactory.ToDomain(packageEntity);
        }
    }
}
