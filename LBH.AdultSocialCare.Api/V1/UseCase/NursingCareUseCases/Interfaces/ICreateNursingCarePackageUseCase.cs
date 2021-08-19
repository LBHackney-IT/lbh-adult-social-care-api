using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces
{
    public interface ICreateNursingCarePackageUseCase
    {
        Task<NursingCarePackageResponse> ExecuteAsync(NursingCarePackageForCreationDomain nursingCarePackageForCreation);
    }
}
