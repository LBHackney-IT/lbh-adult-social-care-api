using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IChangeCarePackageReclaimsStatusUseCase
    {
        Task<CarePackageReclaimDomain> ExecuteAsync(Guid reclaimId, ReclaimStatus status);
    }
}
