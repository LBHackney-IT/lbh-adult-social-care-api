using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

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
