using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CareChargeElementTypeGateway : ICareChargeElementTypeGateway
    {
        private readonly DatabaseContext _dbContext;

        public CareChargeElementTypeGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CareChargeElementTypePlainDomain>> GetAllAsync()
        {
            var res = await _dbContext.CareChargeTypes.ToListAsync().ConfigureAwait(false);
            return res.ToElementTypePlainDomain();
        }
    }
}
