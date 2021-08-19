using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface ICreateResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForCreationDomain residentialCarePackageForCreation);
    }
}
