using System;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces
{
    public interface IEndCarePackageReclaimUseCase
    {
        Task<CarePackageReclaimDomain> ExecuteAsync(Guid reclaimId, CarePackageReclaimEndRequest request);
    }
}
