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
    public class GetNursingCareAdditionalNeedsUseCase : IGetNursingCareAdditionalNeedsUseCase
    {
        private readonly INursingCareAdditionalNeedsGateway _gateway;
        public GetNursingCareAdditionalNeedsUseCase(INursingCareAdditionalNeedsGateway nursingCareAdditionalNeedsGateway)
        {
            _gateway = nursingCareAdditionalNeedsGateway;
        }

        public async Task<NursingCareAdditionalNeedsDomain> GetAsync(Guid nursingCareAdditionalNeedsId)
        {
            var nursingCareAdditionalNeedsEntity = await _gateway.GetAsync(nursingCareAdditionalNeedsId).ConfigureAwait(false);
            return NursingCareAdditionalNeedsFactory.ToDomain(nursingCareAdditionalNeedsEntity);
        }
    }
}
