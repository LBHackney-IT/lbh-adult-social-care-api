using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICreateCarePackageUseCase
    {
        public Task<CarePackagePlainResponse> ResidentialAsync(
            ResidentialCarePackageForCreationDomain residentialCarePackageForCreation);
    }
}
