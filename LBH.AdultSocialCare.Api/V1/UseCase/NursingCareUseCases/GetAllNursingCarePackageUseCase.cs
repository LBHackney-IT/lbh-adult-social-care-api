using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases
{
    public class GetAllNursingCarePackageUseCase : IGetAllNursingCarePackageUseCase
    {
        private readonly INursingCarePackageGateway _gateway;
        public GetAllNursingCarePackageUseCase(INursingCarePackageGateway nursingCareAdditionalNeedsGateway)
        {
            _gateway = nursingCareAdditionalNeedsGateway;
        }

        public async Task<IList<NursingCarePackage>> GetAllAsync()
        {
            var result = await _gateway.ListAsync().ConfigureAwait(false);
            return result;
        }
    }
}
