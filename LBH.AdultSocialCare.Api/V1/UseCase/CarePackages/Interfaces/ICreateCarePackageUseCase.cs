using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICreateCarePackageUseCase
    {
        public Task<CarePackagePlainResponse> CreateAsync(
            CarePackageForCreationDomain carePackageForCreation);
    }
}
