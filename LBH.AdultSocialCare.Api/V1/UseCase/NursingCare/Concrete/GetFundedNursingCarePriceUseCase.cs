using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete
{
    public class GetFundedNursingCarePriceUseCase : IGetFundedNursingCarePriceUseCase
    {
        private readonly IFundedNursingCaseGateway _gateway;

        public GetFundedNursingCarePriceUseCase(IFundedNursingCaseGateway gateway)
        {
            _gateway = gateway;
        }

        public async Task<decimal> GetActiveFundedNursingCarePrice()
        {
            return await GetFundedNursingCarePrice(DateTimeOffset.Now).ConfigureAwait(false);
        }

        public async Task<decimal> GetFundedNursingCarePrice(DateTimeOffset dateTime)
        {
            return await _gateway
                .GetFundedNursingCarePrice(dateTime)
                .ConfigureAwait(false);
        }
    }
}
