using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface ICreateDayCarePackageUseCase
    {
        Task<DayCarePackageResponse> Execute(DayCarePackageForCreationDomain dayCarePackageForCreationDomain);
    }
}
