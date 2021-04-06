using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class UpsertPackageUseCase : IUpsertPackageUseCase
    {
        private readonly IPackageGateway _gateway;
        public UpsertPackageUseCase(IPackageGateway packageGateway)
        {
            _gateway = packageGateway;
        }

        public async Task<PackageDomain> ExecuteAsync(PackageDomain package)
        {
            Package packageEntity = PackageFactory.ToEntity(package);
            packageEntity = await _gateway.UpsertAsync(packageEntity).ConfigureAwait(false);
            if (packageEntity == null) return package = null;
            else
            {
                package = PackageFactory.ToDomain(packageEntity);
            }
            return package;
        }
    }
}
