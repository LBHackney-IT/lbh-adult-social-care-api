using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CareChargeUseCase : ICareChargeUseCase
    {
        private readonly ICareChargesGateway _careChargesGateway;

        public CareChargeUseCase(ICareChargesGateway careChargesGateway)
        {
            _careChargesGateway = careChargesGateway;
        }

        public async Task<ProvisionalCareChargeAmountPlainResponse> GetUsingServiceUserIdAsync(Guid serviceUserId)
        {
            var res = await _careChargesGateway.GetUsingServiceUserIdAsync(serviceUserId).ConfigureAwait(false);

            return res?.ToResponse();
        }
    }
}
