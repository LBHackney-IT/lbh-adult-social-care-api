using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases
{
    public class DeleteResidentialCareAdditionalNeedsUseCase : IDeleteResidentialCareAdditionalNeedsUseCase
    {
        private readonly IResidentialCareAdditionalNeedsGateway _gateway;
        public DeleteResidentialCareAdditionalNeedsUseCase(IResidentialCareAdditionalNeedsGateway residentialCareAdditionalNeedsGateway)
        {
            _gateway = residentialCareAdditionalNeedsGateway;
        }

        public async Task<bool> DeleteAsync(Guid residentialCareAdditionalNeedsId)
        {
            return await _gateway.DeleteAsync(residentialCareAdditionalNeedsId).ConfigureAwait(false);
        }
    }
}
