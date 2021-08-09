using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareAdditionalNeedsDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class UpsertResidentialCareAdditionalNeedsUseCase : IUpsertResidentialCareAdditionalNeedsUseCase
    {
        private readonly IResidentialCareAdditionalNeedsGateway _gateway;

        public UpsertResidentialCareAdditionalNeedsUseCase(IResidentialCareAdditionalNeedsGateway residentialCareAdditionalNeedsGateway)
        {
            _gateway = residentialCareAdditionalNeedsGateway;
        }

        public async Task<ResidentialCareAdditionalNeedsDomain> ExecuteAsync(ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeeds)
        {
            var residentialCareAdditionalNeedsEntity = residentialCareAdditionalNeeds.ToEntity();
            residentialCareAdditionalNeedsEntity = await _gateway.UpsertAsync(residentialCareAdditionalNeedsEntity).ConfigureAwait(false);
            return residentialCareAdditionalNeedsEntity?.ToDomain();
        }
    }
}
