using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class RolesFactory
    {
        public static RolesDomain ToDomain(Role roleEntity)
        {
            return new RolesDomain
            {
                Id = roleEntity.Id,
                RoleName = roleEntity.RoleName,
                IsDefault = roleEntity.IsDefault,
                Sequence = roleEntity.Sequence,
                CreatorId = roleEntity.CreatorId,
                DateCreated = roleEntity.DateCreated,
                UpdatorId = roleEntity.UpdatorId,
                DateUpdated = roleEntity.DateUpdated
            };
        }

        public static Role ToEntity(RolesDomain rolesDomain)
        {
            return new Role
            {
                Id = rolesDomain.Id,
                RoleName = rolesDomain.RoleName,
                IsDefault = rolesDomain.IsDefault,
                Sequence = rolesDomain.Sequence,
                CreatorId = rolesDomain.CreatorId,
                UpdatorId = rolesDomain.UpdatorId
            };
        }

        public static RolesResponse ToResponse(RolesDomain rolesDomain)
        {
            return new RolesResponse
            {
                Id = rolesDomain.Id,
                RoleName = rolesDomain.RoleName,
                IsDefault = rolesDomain.IsDefault,
                Sequence = rolesDomain.Sequence,
                CreatorId = rolesDomain.CreatorId,
                DateCreated = rolesDomain.DateCreated,
                UpdatorId = rolesDomain.UpdatorId,
                DateUpdated = rolesDomain.DateUpdated
            };
        }

        public static RolesDomain ToDomain(RolesRequest rolesEntity)
        {
            return new RolesDomain
            {
                Id = rolesEntity.Id,
                RoleName = rolesEntity.RoleName,
                IsDefault = rolesEntity.IsDefault,
                CreatorId = rolesEntity.CreatorId,
                DateCreated = rolesEntity.DateCreated,
                UpdatorId = rolesEntity.UpdatorId,
                DateUpdated = rolesEntity.DateUpdated
            };
        }
    }
}
