using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete
{
    public class UpsertNursingCareAdditionalNeedsUseCase : IUpsertNursingCareAdditionalNeedsUseCase
    {
        private readonly INursingCareAdditionalNeedsGateway _gateway;

        public UpsertNursingCareAdditionalNeedsUseCase(INursingCareAdditionalNeedsGateway nursingCareAdditionalNeedsGateway)
        {
            _gateway = nursingCareAdditionalNeedsGateway;
        }

        public async Task<NursingCareAdditionalNeedsDomain> ExecuteAsync(NursingCareAdditionalNeedsDomain nursingCareAdditionalNeeds)
        {
            var nursingCareAdditionalNeedsEntity = nursingCareAdditionalNeeds.ToEntity();
            nursingCareAdditionalNeedsEntity = await _gateway.UpsertAsync(nursingCareAdditionalNeedsEntity).ConfigureAwait(false);
            return nursingCareAdditionalNeedsEntity?.ToDomain();
        }
    }
}
