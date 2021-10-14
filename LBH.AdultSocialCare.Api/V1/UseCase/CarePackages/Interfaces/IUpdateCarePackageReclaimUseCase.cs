using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IUpdateCarePackageReclaimUseCase
    {
        Task<bool> UpdateCarePackageReclaim(CarePackageReclaimForUpdateDomain carePackageReclaimForUpdateDomain);
    }
}
