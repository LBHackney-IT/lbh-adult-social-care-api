using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICreateCarePackageReclaimUseCase
    {
        Task<CarePackageReclaimResponse> CreateCarePackageReclaim(CarePackageReclaimCreationDomain carePackageReclaimCreationDomain);
    }
}
