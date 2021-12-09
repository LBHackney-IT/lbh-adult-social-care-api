using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using System;
using System.Threading.Tasks;
using Common.Helpers;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class GetFundedNursingCarePriceUseCase : IGetFundedNursingCarePriceUseCase
    {
        private readonly IFundedNursingCareGateway _gateway;

        public GetFundedNursingCarePriceUseCase(IFundedNursingCareGateway gateway)
        {
            _gateway = gateway;
        }

        public ICurrentDateProvider CurrentDateProvider { get; set; } = new CurrentDateProvider();

        public async Task<decimal> GetActiveFundedNursingCarePriceAsync()
        {
            return await GetFundedNursingCarePriceAsync(CurrentDateProvider.Now)
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
