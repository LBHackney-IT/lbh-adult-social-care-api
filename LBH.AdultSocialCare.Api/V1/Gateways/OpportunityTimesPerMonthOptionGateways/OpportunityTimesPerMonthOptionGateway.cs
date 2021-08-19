using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.OpportunityTimesPerMonthOptionGateways
{
    public class OpportunityTimesPerMonthOptionGateway : IOpportunityTimesPerMonthOptionGateway
    {
        private readonly DatabaseContext _dbContext;

        public OpportunityTimesPerMonthOptionGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OpportunityTimesPerMonthOptionDomain>> GetOpportunityTimesPerMonthOptionsList()
        {
            var opportunityTimesPerMonthOptions = await _dbContext.OpportunityTimesPerMonthOptions
                .AsNoTracking()
                .ToListAsync().ConfigureAwait(false);
            return opportunityTimesPerMonthOptions?.ToDomain();
        }
    }
}
