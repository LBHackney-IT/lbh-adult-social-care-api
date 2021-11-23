using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Security.Concrete
{
    public class RolesGateway : IRolesGateway
    {
        private readonly DatabaseContext _databaseContext;

        public RolesGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<RolesDomain> GetAsync(Guid roleId)
        {
            var res = await _databaseContext.Roles.FirstOrDefaultAsync(item => item.Id == roleId).ConfigureAwait(false);
            return res?.ToDomain();
        }

        public async Task<IList<RolesDomain>> ListAsync()
        {
            var res = await _databaseContext.Roles.ToListAsync().ConfigureAwait(false);
            return res.ToDomain();
        }
    }
}
