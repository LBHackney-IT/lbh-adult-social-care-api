using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;

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
            var nursingCareAdditionalNeedsEntity = NursingCareAdditionalNeedsFactory.ToEntity(nursingCareAdditionalNeeds);
            nursingCareAdditionalNeedsEntity = await _gateway.UpsertAsync(nursingCareAdditionalNeedsEntity).ConfigureAwait(false);
            if (nursingCareAdditionalNeedsEntity == null) return nursingCareAdditionalNeeds = null;
            else
            {
                nursingCareAdditionalNeeds = NursingCareAdditionalNeedsFactory.ToDomain(nursingCareAdditionalNeedsEntity);
            }
            return nursingCareAdditionalNeeds;
        }
    }
}
