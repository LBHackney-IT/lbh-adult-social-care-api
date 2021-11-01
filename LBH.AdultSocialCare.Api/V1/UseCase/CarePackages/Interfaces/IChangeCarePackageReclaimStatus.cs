using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface ICancelCarePackageReclaimsUseCase
    {
        Task<CarePackageReclaimDomain> ExecuteAsync(Guid reclaimId);
    }
}
