using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways.Interfaces;
using BaseApi.V1.Infrastructure.Entities;
using BaseApi.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase
{
    public class UpdateHomeCarePackageUseCase : IUpdateHomeCarePackageUseCase
    {
        private readonly IHomeCarePackageGateway _gateway;
        public UpdateHomeCarePackageUseCase(IHomeCarePackageGateway homeCarePackageGateway)
        {
            _gateway = homeCarePackageGateway;
        }

        public async Task<HomeCarePackageDomain> UpdateAsync(HomeCarePackageDomain homeCarePackage)
        {
            var homeCarePackageEntity = HomeCarePackageFactory.ToEntity(homeCarePackage);
            homeCarePackageEntity = await _gateway.UpdateAsync(homeCarePackageEntity).ConfigureAwait(false);
            if (homeCarePackageEntity == null) return homeCarePackage = null;
            else
            {
                homeCarePackage = HomeCarePackageFactory.ToDomain(homeCarePackageEntity);
            }
            return homeCarePackage;
        }
    }
}
