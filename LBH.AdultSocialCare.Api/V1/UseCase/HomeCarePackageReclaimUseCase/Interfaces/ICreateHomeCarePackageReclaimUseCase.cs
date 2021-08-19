using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Response;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCarePackageReclaimDomains;

namespace LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces
{
    public interface ICreateHomeCarePackageReclaimUseCase
    {
        Task<HomeCarePackageClaimResponse> ExecuteAsync(HomeCarePackageClaimCreationDomain homeCarePackageClaimCreationDomain);
    }
}
