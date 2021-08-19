using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Security;

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
            _databaseContext.Roles.Remove(new Role()
            { Id = roleId });
            var isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
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

        public async Task<RolesDomain> UpsertAsync(Role role)
        {
            var roleToUpdate = await _databaseContext.Roles.FirstOrDefaultAsync(item => item.NormalizedName.Trim() == role.NormalizedName.Trim()).ConfigureAwait(false);
            if (roleToUpdate == null)
            {
                await _databaseContext.Roles.AddAsync(role).ConfigureAwait(false);
            }
            else
            {
                throw new EntityConflictException($"Role with name {role.Name} already exists");
            }
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return role?.ToDomain();
        }
    }
}
