using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface IUpdateNursingCarePackageUseCase
    {
        public Task<NursingCarePackageResponse> ExecuteAsync(NursingCarePackageForUpdateDomain nursingCarePackageForUpdate);
    }
}
