using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageHistoryGateway
    {
        Task<IEnumerable<CarePackageHistoryDomain>> ListAsync(Guid carePackageId);
    }
}
