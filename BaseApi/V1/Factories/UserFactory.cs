using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Factories
{
    public static class UserFactory
    {
        public static UsersDomain ToDomain(Users usersEntity)
        {
            return new UsersDomain()
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
                Roles = usersEntity.Roles,
                CreatorId = usersEntity.CreatorId,
                DateCreated = usersEntity.DateCreated,
                UpdatorId = usersEntity.UpdatorId,
                DateUpdated = usersEntity.DateUpdated,
                Success = usersEntity.Success,
                Message = usersEntity.Message
            };
        }

        public static Users ToEntity(UsersDomain usersDomain)
        {
            return new Users()
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
                Roles = usersDomain.Roles,
                CreatorId = usersDomain.CreatorId,
                DateCreated = usersDomain.DateCreated,
                UpdatorId = usersDomain.UpdatorId,
                DateUpdated = usersDomain.DateUpdated,
                Success = usersDomain.Success,
                Message = usersDomain.Message
            };
        }

        public static UsersResponse ToResponse(UsersDomain usersDomain)
        {
            return new UsersResponse()
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
                Roles = usersDomain.Roles,
                CreatorId = usersDomain.CreatorId,
                DateCreated = usersDomain.DateCreated,
                UpdatorId = usersDomain.UpdatorId,
                DateUpdated = usersDomain.DateUpdated,
                Success = usersDomain.Success,
                Message = usersDomain.Message
            };
        }

        public static UsersDomain ToDomain(UsersResponse usersEntity)
        {
            return new UsersDomain()
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
                Roles = usersEntity.Roles,
                CreatorId = usersEntity.CreatorId,
                DateCreated = usersEntity.DateCreated,
                UpdatorId = usersEntity.UpdatorId,
                DateUpdated = usersEntity.DateUpdated,
                Success = usersEntity.Success,
                Message = usersEntity.Message
            };
        }
    }
}
