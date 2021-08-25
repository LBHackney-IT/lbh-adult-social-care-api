using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class PackageCostClaimersGateway : IPackageCostClaimersGateway
    {
        private readonly DatabaseContext _context;

        public PackageCostClaimersGateway(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FundedNursingCareCollectorDomain>> GetFundedNursingCareCollectorsAsync()
        {
            var collectors = await _context.FundedNursingCareCollectors
                .ToListAsync()
                .ConfigureAwait(false);

            return collectors?.ToDomain();
        }
    }
}
