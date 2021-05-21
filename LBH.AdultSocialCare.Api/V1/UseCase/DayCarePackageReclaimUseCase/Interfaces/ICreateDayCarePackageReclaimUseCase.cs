using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.DayCarePackageReclaimBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain.DayCarePackageReclaimDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageReclaimUseCase.Interfaces
{
    public interface ICreateDayCarePackageReclaimUseCase
    {
        Task<DayCarePackageClaimResponse> ExecuteAsync(DayCarePackageClaimCreationDomain dayCarePackageClaimCreationDomain);
    }
}
