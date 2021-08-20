using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
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
