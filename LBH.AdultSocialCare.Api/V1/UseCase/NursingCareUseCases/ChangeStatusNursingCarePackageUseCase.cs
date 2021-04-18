using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases
{
    public class ChangeStatusNursingCarePackageUseCase : IChangeStatusNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        public ChangeStatusNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<NursingCarePackageDomain> UpdateAsync(Guid nursingCarePackageId, int statusId)
        {
            var nursingCarePackageEntity = await _gateway.ChangeStatusAsync(nursingCarePackageId, statusId).ConfigureAwait(false);
            if (nursingCarePackageEntity == null) return null;
            else
            {
                return NursingCarePackageFactory.ToDomain(nursingCarePackageEntity);
            }
        }
    }
}
