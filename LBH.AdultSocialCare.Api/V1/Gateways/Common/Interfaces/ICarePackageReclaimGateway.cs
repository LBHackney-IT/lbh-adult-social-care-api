using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageReclaimGateway
    {
        Task<CarePackageReclaimDomain> CreateCarePackageReclaim(CarePackageReclaim carePackageReclaim);
        Task<bool> UpdateCarePackageReclaim(CarePackageReclaimForUpdateDomain carePackageReclaimForUpdateDomain);
        Task<CarePackageReclaimDomain> GetCarePackageReclaim(Guid carePackageId, ReclaimType reclaimType);
    }
}
