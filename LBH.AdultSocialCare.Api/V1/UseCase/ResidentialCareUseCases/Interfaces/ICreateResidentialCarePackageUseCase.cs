using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces
{
    public interface ICreateResidentialCarePackageUseCase
    {
        Task<ResidentialCarePackageResponse> ExecuteAsync(ResidentialCarePackageForCreationDomain residentialCarePackageForCreation);
    }
}
