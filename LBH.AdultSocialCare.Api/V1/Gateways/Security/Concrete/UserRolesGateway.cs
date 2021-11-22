using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using LBH.AdultSocialCare.Data;
using LBH.AdultSocialCare.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Security.Concrete
{
    public class UserRolesGateway : IUserRolesGateway
    {
        private readonly DatabaseContext _dbContext;

        public UserRolesGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AppUserRole>> GetUserRolesAsync(Guid userId, bool trackChanges = false)
        {
            return await _dbContext.UserRoles.Where(ur => ur.UserId == userId).TrackChanges(trackChanges)
                .ToListAsync();
        }

        public void RemoveUserRoles(IEnumerable<AppUserRole> userRoles)
        {
            _dbContext.UserRoles.RemoveRange(userRoles);
        }
    }
}
