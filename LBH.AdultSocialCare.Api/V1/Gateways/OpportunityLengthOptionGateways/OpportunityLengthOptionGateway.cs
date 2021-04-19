using LBH.AdultSocialCare.Api.V1.Domain.OpportunityLengthOptionDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.OpportunityLengthOptionGateways
{
    public class OpportunityLengthOptionGateway : IOpportunityLengthOptionGateway
    {
        private readonly DatabaseContext _dbContext;

        public OpportunityLengthOptionGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OpportunityLengthOptionDomain>> GetOpportunityLengthOptionsList()
        {
            var opportunityLengthOptions = await _dbContext.OpportunityLengthOptions
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
            return opportunityLengthOptions?.ToDomain();
        }
    }
}
