using Common.AppConstants.Enums;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces
{
    public interface IGetEndDateOfLastPayRunUseCase
    {
        Task<DateTimeOffset> GetAsync(PayrunType type);
    }
}
