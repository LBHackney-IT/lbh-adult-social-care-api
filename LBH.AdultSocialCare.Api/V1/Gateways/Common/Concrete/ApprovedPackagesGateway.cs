using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class ApprovedPackagesGateway : IApprovedPackagesGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ApprovedPackagesGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<UsersMinimalDomain>> GetUsers(Guid roleId)
        {
            var result = await _databaseContext.Roles
                .Join(_databaseContext.UserRoles,
                    role => role.Id,
                    userRole => userRole.RoleId,
                    (role, userRole) => new { RoleId = role.Id, userRole.UserId })
                .Join(_databaseContext.Users,
                    userRole => userRole.UserId,
                    user => user.Id,
                    (userRole, user) => new { userRole.RoleId, user.Name, user.Id })
                .Where(userInfo => userInfo.RoleId == roleId)
                .Select(userInfo => new UsersMinimalDomain { Id = userInfo.Id, UserName = userInfo.Name })
                .ToListAsync().ConfigureAwait(false);

            return result;
        }
    }
}
