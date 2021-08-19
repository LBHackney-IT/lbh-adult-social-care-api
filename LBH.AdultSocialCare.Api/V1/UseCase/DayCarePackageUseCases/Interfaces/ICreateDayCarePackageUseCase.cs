using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageDomains;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface ICreateDayCarePackageUseCase
    {
        Task<DayCarePackageResponse> Execute(DayCarePackageForCreationDomain dayCarePackageForCreationDomain);
    }
}
