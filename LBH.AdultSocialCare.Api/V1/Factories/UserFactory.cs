using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class UserFactory
    {
        public static UsersDomain ToDomain(User userEntity)
        {
            return new UsersDomain
            {
                Id = userEntity.Id,
                FirstName = userEntity.FirstName,
                MiddleName = userEntity.MiddleName,
                LastName = userEntity.LastName,
                HackneyId = userEntity.HackneyId,
                AddressLine1 = userEntity.AddressLine1,
                AddressLine2 = userEntity.AddressLine2,
                AddressLine3 = userEntity.AddressLine3,
                Town = userEntity.Town,
                County = userEntity.County,
                PostCode = userEntity.PostCode,
                RoleId = userEntity.RoleId,
                Role = userEntity.Role,
                CreatorId = userEntity.CreatorId,
                DateCreated = userEntity.DateCreated,
                UpdatorId = userEntity.UpdatorId,
                DateUpdated = userEntity.DateUpdated
            };
        }

        public static User ToEntity(UsersDomain usersDomain)
        {
            return new User
            {
                Id = usersDomain.Id,
                FirstName = usersDomain.FirstName,
                MiddleName = usersDomain.MiddleName,
                LastName = usersDomain.LastName,
                HackneyId = usersDomain.HackneyId,
                AddressLine1 = usersDomain.AddressLine1,
                AddressLine2 = usersDomain.AddressLine2,
                AddressLine3 = usersDomain.AddressLine3,
                Town = usersDomain.Town,
                County = usersDomain.County,
                PostCode = usersDomain.PostCode,
                RoleId = usersDomain.RoleId,
                Role = usersDomain.Role,
                CreatorId = usersDomain.CreatorId,
                UpdatorId = usersDomain.UpdatorId,
            };
        }

        public static UsersResponse ToResponse(UsersDomain usersDomain)
        {
            return new UsersResponse
            {
                Id = usersDomain.Id,
                FirstName = usersDomain.FirstName,
                MiddleName = usersDomain.MiddleName,
                LastName = usersDomain.LastName,
                HackneyId = usersDomain.HackneyId,
                AddressLine1 = usersDomain.AddressLine1,
                AddressLine2 = usersDomain.AddressLine2,
                AddressLine3 = usersDomain.AddressLine3,
                Town = usersDomain.Town,
                County = usersDomain.County,
                PostCode = usersDomain.PostCode,
                RoleId = usersDomain.RoleId,
                Role = usersDomain.Role,
                CreatorId = usersDomain.CreatorId,
                DateCreated = usersDomain.DateCreated,
                UpdatorId = usersDomain.UpdatorId,
                DateUpdated = usersDomain.DateUpdated
            };
        }

        public static UsersDomain ToDomain(UsersRequest usersEntity)
        {
            return new UsersDomain
            {
                Id = usersEntity.Id,
                FirstName = usersEntity.FirstName,
                MiddleName = usersEntity.MiddleName,
                LastName = usersEntity.LastName,
                HackneyId = usersEntity.HackneyId,
                AddressLine1 = usersEntity.AddressLine1,
                AddressLine2 = usersEntity.AddressLine2,
                AddressLine3 = usersEntity.AddressLine3,
                Town = usersEntity.Town,
                County = usersEntity.County,
                PostCode = usersEntity.PostCode,
                RoleId = usersEntity.RoleId,
                CreatorId = usersEntity.CreatorId,
                DateCreated = usersEntity.DateCreated,
                UpdatorId = usersEntity.UpdatorId,
                DateUpdated = usersEntity.DateUpdated
            };
        }
    }
}
