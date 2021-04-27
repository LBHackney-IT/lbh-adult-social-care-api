using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IGetNursingCareAdditionalNeedsUseCase
    {
        public Task<NursingCareAdditionalNeedsDomain> GetAsync(Guid nursingCareAdditionalNeedsId);
    }
}