using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class UpsertNursingCarePackageUseCase : IUpsertNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        public UpsertNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<NursingCarePackageDomain> ExecuteAsync(NursingCarePackageDomain nursingCarePackage)
        {
            var nursingCarePackageEntity = NursingCarePackageFactory.ToEntity(nursingCarePackage);
            nursingCarePackageEntity = await _gateway.UpsertAsync(nursingCarePackageEntity).ConfigureAwait(false);
            if (nursingCarePackageEntity == null) return nursingCarePackage = null;
            else
            {
                nursingCarePackage = NursingCarePackageFactory.ToDomain(nursingCarePackageEntity);
            }
            return nursingCarePackage;
        }
    }
}
