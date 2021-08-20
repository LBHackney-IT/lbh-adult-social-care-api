using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCare;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces
{
    public interface ICreateDayCarePackageUseCase
    {
        Task<DayCarePackageResponse> Execute(DayCarePackageForCreationDomain dayCarePackageForCreationDomain);
    }
}
