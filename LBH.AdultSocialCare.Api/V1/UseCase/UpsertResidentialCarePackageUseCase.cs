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
    public class UpsertResidentialCarePackageUseCase : IUpsertResidentialCarePackageUseCase
    {
        private readonly IResidentialCarePackageGateway _gateway;
        public UpsertResidentialCarePackageUseCase(IResidentialCarePackageGateway residentialcarePackageGateway)
        {
            _gateway = residentialcarePackageGateway;
        }
        public async Task<ResidentialCarePackageDomain> ExecuteAsync(ResidentialCarePackageDomain residentialCarePackage)
        {
            var homeCarePackageEntity = ResidentialCarePackageFactory.ToEntity(residentialCarePackage);
            homeCarePackageEntity = await _gateway.UpsertAsync(homeCarePackageEntity).ConfigureAwait(false);
            if (homeCarePackageEntity == null) return residentialCarePackage = null;
            else
            {
                residentialCarePackage = ResidentialCarePackageFactory.ToDomain(homeCarePackageEntity);
            }
            return residentialCarePackage;
        }
    }
}
