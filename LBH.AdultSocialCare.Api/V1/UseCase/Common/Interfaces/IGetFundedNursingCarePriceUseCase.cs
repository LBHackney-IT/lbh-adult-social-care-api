using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IGetFundedNursingCarePriceUseCase
    {
        public Task<decimal> GetActiveFundedNursingCarePriceAsync();

        public Task<decimal> GetFundedNursingCarePriceAsync(DateTimeOffset dateTime);
    }
}
