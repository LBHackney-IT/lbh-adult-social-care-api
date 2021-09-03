using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Helpers;
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

        public ICurrentDateTimeProvider CurrentDateTimeProvider { get; set; } = new CurrentDateTimeProvider();

        public async Task<decimal> GetActiveFundedNursingCarePriceAsync()
        {
            return await GetFundedNursingCarePriceAsync(CurrentDateTimeProvider.Now)
                .ConfigureAwait(false);
        }

        public async Task<decimal> GetFundedNursingCarePriceAsync(DateTimeOffset dateTime)
        {
            return await _gateway
                .GetFundedNursingCarePriceAsync(dateTime)
                .ConfigureAwait(false);
        }
    }
}
