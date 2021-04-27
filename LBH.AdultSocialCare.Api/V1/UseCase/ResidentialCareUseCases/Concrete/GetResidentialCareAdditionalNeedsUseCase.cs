using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete
{
    public class GetResidentialCareAdditionalNeedsUseCase : IGetResidentialCareAdditionalNeedsUseCase
    {
        private readonly IResidentialCareAdditionalNeedsGateway _gateway;
        public GetResidentialCareAdditionalNeedsUseCase(IResidentialCareAdditionalNeedsGateway residentialCareAdditionalNeedsGateway)
        {
            _gateway = residentialCareAdditionalNeedsGateway;
        }

        public async Task<ResidentialCareAdditionalNeedsDomain> GetAsync(Guid residentialCareAdditionalNeedsId)
        {
            var residentialCareAdditionalNeedsEntity = await _gateway.GetAsync(residentialCareAdditionalNeedsId).ConfigureAwait(false);
            return ResidentialCareAdditionalNeedsFactory.ToDomain(residentialCareAdditionalNeedsEntity);
        }
    }
}
