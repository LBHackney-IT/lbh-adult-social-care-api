using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DeleteAsync(int roleId)
        {
            var result = _databaseContext.Roles.Remove(new Role
            { Id = roleId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<Role> GetAsync(int roleId)
        {
            return await _databaseContext.Roles.FirstOrDefaultAsync(item => item.Id == roleId).ConfigureAwait(false);
        }

        public async Task<IList<Role>> ListAsync()
        {
            return await _databaseContext.Roles.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Role> UpsertAsync(Role role)
        {
            Role roleToUpdate = await _databaseContext.Roles.FirstOrDefaultAsync(item => item.RoleName == role.RoleName).ConfigureAwait(false);
            if (roleToUpdate == null)
            {
                roleToUpdate = new Role();
                await _databaseContext.Roles.AddAsync(roleToUpdate).ConfigureAwait(false);
                roleToUpdate.RoleName = role.RoleName;
                roleToUpdate.Sequence = role.Sequence;
                roleToUpdate.IsDefault = role.IsDefault;
                roleToUpdate.CreatorId = role.CreatorId;
                roleToUpdate.UpdatorId = role.UpdatorId;
                roleToUpdate.DateUpdated = role.DateUpdated;
            }
            else
            {
                throw new ApiException($"This record already exist Role Name: {role.RoleName}");
            }
            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
            return roleToUpdate;
        }
    }
}
