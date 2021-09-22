using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageDetailGateway
    {
        Task<IEnumerable<CarePackageDetailDomain>> GetCarePackageDetails(Guid carePackageId);
    }
}
