using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface IUpdateResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForUpdateDomain residentialCarePackageForUpdate);
    }
}
