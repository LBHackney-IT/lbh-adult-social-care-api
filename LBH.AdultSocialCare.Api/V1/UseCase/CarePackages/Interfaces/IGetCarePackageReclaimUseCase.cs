using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IGetCarePackageReclaimUseCase
    {
        Task<CarePackageReclaimResponse> GetCarePackageReclaim(Guid carePackageId, ReclaimType reclaimType);
    }
}
