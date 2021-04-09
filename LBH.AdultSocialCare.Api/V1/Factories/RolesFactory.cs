using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
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
                DateUpdated = rolesEntity.DateUpdated
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
                DateUpdated = rolesDomain.DateUpdated
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
                DateUpdated = rolesDomain.DateUpdated
            };
        }

        public static RolesDomain ToDomain(RolesRequest rolesEntity)
        {
            return new RolesDomain()
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
