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

        public ICurrentDateTimeOffsetProvider CurrentDateTimeOffsetProvider { get; set; } = new CurrentDateTimeOffsetProvider();

        public async Task<decimal> GetActiveFundedNursingCarePriceAsync()
        {
            return await GetFundedNursingCarePriceAsync(CurrentDateTimeOffsetProvider.Now)
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
