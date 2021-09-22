using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageReclaimGateway
    {
        Task<IEnumerable<CarePackageReclaimDomain>> GetCarePackageReclaims(Guid carePackageId);
    }
}
