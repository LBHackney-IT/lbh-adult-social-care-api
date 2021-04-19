using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases
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
            var residentialCareAdditionalNeedsEntity = ResidentialCareAdditionalNeedsFactory.ToEntity(residentialCareAdditionalNeeds);
            residentialCareAdditionalNeedsEntity = await _gateway.UpsertAsync(residentialCareAdditionalNeedsEntity).ConfigureAwait(false);
            if (residentialCareAdditionalNeedsEntity == null) return residentialCareAdditionalNeeds = null;
            else
            {
                residentialCareAdditionalNeeds = ResidentialCareAdditionalNeedsFactory.ToDomain(residentialCareAdditionalNeedsEntity);
            }
            return residentialCareAdditionalNeeds;
        }
    }
}
