using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IUpsertNursingCareAdditionalNeedsUseCase
    {
        public Task<NursingCareAdditionalNeedsDomain> ExecuteAsync(NursingCareAdditionalNeedsDomain nursingCareAdditionalNeeds);
    }
}