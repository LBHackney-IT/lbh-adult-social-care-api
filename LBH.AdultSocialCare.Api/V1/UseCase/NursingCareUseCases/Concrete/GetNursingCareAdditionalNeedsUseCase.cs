using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
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
