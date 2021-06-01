using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Interfaces
{
    public interface ICreateResidentialCarePackageUseCase
    {
        public Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForCreationDomain residentialCarePackageForCreation);
    }
}
