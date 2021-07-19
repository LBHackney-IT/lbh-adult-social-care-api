using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IDeleteNursingCareAdditionalNeedsUseCase
    {
        public Task<bool> DeleteAsync(Guid nursingCareAdditionalNeedsId);
    }
}
