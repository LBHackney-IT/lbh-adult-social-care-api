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
        Task<CarePackageReclaimDomain> Create(CarePackageReclaim carePackageReclaim);
        Task<bool> Update(CarePackageReclaimForUpdateDomain carePackageReclaimForUpdateDomain);
        Task<CarePackageReclaimDomain> Get(Guid carePackageId, ReclaimType reclaimType);
    }
}
