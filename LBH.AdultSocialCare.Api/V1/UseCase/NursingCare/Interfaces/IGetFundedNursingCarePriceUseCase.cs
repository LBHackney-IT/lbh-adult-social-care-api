using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface IGetFundedNursingCarePriceUseCase
    {
        public Task<decimal> GetActiveFundedNursingCarePrice();

        public Task<decimal> GetFundedNursingCarePrice(DateTimeOffset dateTime);
    }
}