using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface IUpsertNursingCareAdditionalNeedsUseCase
    {
        public Task<NursingCareAdditionalNeedsDomain> ExecuteAsync(NursingCareAdditionalNeedsDomain nursingCareAdditionalNeeds);
    }
}
