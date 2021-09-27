using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICreateCarePackageUseCase
    {
        public Task<CarePackagePlainResponse> CreateAsync(
            CarePackageForCreationDomain carePackageForCreation);
    }
}
