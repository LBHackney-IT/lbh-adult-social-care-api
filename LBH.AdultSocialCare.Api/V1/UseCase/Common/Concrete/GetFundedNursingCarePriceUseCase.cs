using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetFundedNursingCarePriceUseCase : IGetFundedNursingCarePriceUseCase
    {
        private readonly IFundedNursingCareGateway _gateway;

        public GetFundedNursingCarePriceUseCase(IFundedNursingCareGateway gateway)
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
