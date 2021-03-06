using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
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
