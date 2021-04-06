using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Factories
{
    public static class RolesFactory
    {
        public static RolesDomain ToDomain(Roles rolesEntity)
        {
            return new RolesDomain()
            {
                Id = rolesEntity.Id,
                RoleName = rolesEntity.RoleName,
                IsDefault = rolesEntity.IsDefault,
                Sequence = rolesEntity.Sequence,
                CreatorId = rolesEntity.CreatorId,
                DateCreated = rolesEntity.DateCreated,
                UpdatorId = rolesEntity.UpdatorId,
                DateUpdated = rolesEntity.DateUpdated,
                Success = rolesEntity.Success,
                Message = rolesEntity.Message
            };
        }

        public static Roles ToEntity(RolesDomain rolesDomain)
        {
            return new Roles()
            {
                Id = rolesDomain.Id,
                RoleName = rolesDomain.RoleName,
                IsDefault = rolesDomain.IsDefault,
                Sequence = rolesDomain.Sequence,
                CreatorId = rolesDomain.CreatorId,
                DateCreated = rolesDomain.DateCreated,
                UpdatorId = rolesDomain.UpdatorId,
                DateUpdated = rolesDomain.DateUpdated,
                Success = rolesDomain.Success,
                Message = rolesDomain.Message
            };
        }

        public static RolesResponse ToResponse(RolesDomain rolesDomain)
        {
            return new RolesResponse()
            {
                Id = rolesDomain.Id,
                RoleName = rolesDomain.RoleName,
                IsDefault = rolesDomain.IsDefault,
                Sequence = rolesDomain.Sequence,
                CreatorId = rolesDomain.CreatorId,
                DateCreated = rolesDomain.DateCreated,
                UpdatorId = rolesDomain.UpdatorId,
                DateUpdated = rolesDomain.DateUpdated,
                Success = rolesDomain.Success,
                Message = rolesDomain.Message
            };
        }

        public static RolesDomain ToDomain(RolesResponse rolesEntity)
        {
            return new RolesDomain()
            {
                Id = rolesEntity.Id,
                RoleName = rolesEntity.RoleName,
                IsDefault = rolesEntity.IsDefault,
                Sequence = rolesEntity.Sequence,
                CreatorId = rolesEntity.CreatorId,
                DateCreated = rolesEntity.DateCreated,
                UpdatorId = rolesEntity.UpdatorId,
                DateUpdated = rolesEntity.DateUpdated,
                Success = rolesEntity.Success,
                Message = rolesEntity.Message
            };
        }
    }
}
