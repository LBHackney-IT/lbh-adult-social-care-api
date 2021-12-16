using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICreateProvisionalCareChargeUseCase
    {
        Task<CarePackageReclaimResponse> CreateProvisionalCareCharge(
            CarePackageReclaimCreationDomain reclaimCreationDomain, ReclaimType reclaimType);
    }
}
