using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
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
