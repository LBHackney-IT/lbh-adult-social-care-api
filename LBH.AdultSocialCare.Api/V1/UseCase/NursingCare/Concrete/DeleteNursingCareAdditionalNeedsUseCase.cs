using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class DeleteNursingCareAdditionalNeedsUseCase : IDeleteNursingCareAdditionalNeedsUseCase
    {
        private readonly INursingCareAdditionalNeedsGateway _gateway;
        public DeleteNursingCareAdditionalNeedsUseCase(INursingCareAdditionalNeedsGateway nursingCareAdditionalNeedsGateway)
        {
            _gateway = nursingCareAdditionalNeedsGateway;
        }

        public async Task<bool> DeleteAsync(Guid nursingCareAdditionalNeedsId)
        {
            return await _gateway.DeleteAsync(nursingCareAdditionalNeedsId).ConfigureAwait(false);
        }
    }
}
