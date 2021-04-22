using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface IUpdateNursingCarePackageUseCase
    {
        public Task<NursingCarePackageResponse> ExecuteAsync(NursingCarePackageForUpdateDomain nursingCarePackageForUpdate);
    }
}
