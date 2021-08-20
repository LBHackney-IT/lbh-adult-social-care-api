using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
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
            return nursingCareAdditionalNeedsEntity?.ToDomain();
        }
    }
}
