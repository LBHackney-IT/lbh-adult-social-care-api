using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.TermTimeConsiderationOptionDomains;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;

namespace LBH.AdultSocialCare.Api.V1.Gateways.TermTimeConsiderationOptionGateways
{
    public class TermTimeConsiderationOptionGateway : ITermTimeConsiderationOptionGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public TermTimeConsiderationOptionGateway(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
