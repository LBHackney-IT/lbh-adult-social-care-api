using LBH.AdultSocialCare.Api.V1.Domain.TermTimeConsiderationOptionDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.TermTimeConsiderationOptionGateways
{
    public class TermTimeConsiderationOptionGateway : ITermTimeConsiderationOptionGateway
    {
        private readonly DatabaseContext _dbContext;

        public TermTimeConsiderationOptionGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TermTimeConsiderationOptionDomain>> GetTermTimeConsiderationOptionsList()
        {
            var dayCarePackageOpportunities = await _dbContext.TermTimeConsiderationOptions
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
            return dayCarePackageOpportunities?.ToDomain();
        }
    }
}
