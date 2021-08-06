using LBH.AdultSocialCare.Api.V1.Domain.PackageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.PrimarySupportReasonGateways
{
    public class PrimarySupportReasonGateway : IPrimarySupportReasonGateway
    {
        private readonly DatabaseContext _databaseContext;

        public PrimarySupportReasonGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<PrimarySupportReasonDomain>> ListAsync()
        {
            var res = await _databaseContext.PrimarySupportReasons
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }
    }
}
