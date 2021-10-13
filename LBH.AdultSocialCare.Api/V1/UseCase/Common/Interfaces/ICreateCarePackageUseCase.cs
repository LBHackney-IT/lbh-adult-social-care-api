using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface ICreateCarePackageUseCase
    {
        public Task<CarePackagePlainResponse> CreateAsync(
            CarePackageForCreationDomain carePackageForCreation);
    }
}
