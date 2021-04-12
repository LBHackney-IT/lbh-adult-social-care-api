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
    public class GetNursingCarePackageUseCase : IGetNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        public GetNursingCarePackageUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _gateway = nursingCarePackageGateway;
        }

        public async Task<NursingCarePackageDomain> GetAsync(Guid nursingCarePackageId)
        {
            var packageEntity = await _gateway.GetAsync(nursingCarePackageId).ConfigureAwait(false);
            return NursingCarePackageFactory.ToDomain(packageEntity);
        }
    }
}
