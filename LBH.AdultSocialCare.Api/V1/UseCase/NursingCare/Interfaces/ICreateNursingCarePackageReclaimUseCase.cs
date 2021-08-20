using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces
{
    public interface ICreateNursingCarePackageReclaimUseCase
    {
        Task<NursingCarePackageClaimResponse> ExecuteAsync(NursingCarePackageClaimCreationDomain nursingCarePackageClaimCreationDomain);
    }
}
