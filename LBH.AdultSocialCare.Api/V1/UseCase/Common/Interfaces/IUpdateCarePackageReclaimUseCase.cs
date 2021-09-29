using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces
{
    public interface IUpdateCarePackageReclaimUseCase
    {
        Task<bool> UpdateCarePackageReclaim(CarePackageReclaimForUpdateDomain carePackageReclaimForUpdateDomain);
    }
}
