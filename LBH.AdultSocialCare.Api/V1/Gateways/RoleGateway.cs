using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class RoleGateway : IRolesGateway
    {
        private readonly DatabaseContext _databaseContext;

        public RoleGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid roleId)
        {
            var result = _databaseContext.Roles.Remove(new Roles
            { Id = roleId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<Roles> GetAsync(Guid roleId)
        {
            return await _databaseContext.Roles.FirstOrDefaultAsync(item => item.Id == roleId).ConfigureAwait(false);
        }

        public async Task<IList<Roles>> ListAsync()
        {
            return await _databaseContext.Roles.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Roles> UpsertAsync(Roles roles)
        {
            Roles rolesToUpdate = await _databaseContext.Roles.FirstOrDefaultAsync(item => item.RoleName == roles.RoleName).ConfigureAwait(false);
            if (rolesToUpdate == null)
            {
                rolesToUpdate = new Roles();
                await _databaseContext.Roles.AddAsync(rolesToUpdate).ConfigureAwait(false);
                rolesToUpdate.RoleName = roles.RoleName;
                rolesToUpdate.Sequence = roles.Sequence;
                rolesToUpdate.IsDefault = roles.IsDefault;
                rolesToUpdate.CreatorId = roles.CreatorId;
                rolesToUpdate.UpdatorId = roles.UpdatorId;
                rolesToUpdate.DateUpdated = roles.DateUpdated;
            }
            else
            {
                throw new ErrorException($"This record already exist Role Name: {roles.RoleName}");
            }
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return rolesToUpdate;
        }
    }
}
