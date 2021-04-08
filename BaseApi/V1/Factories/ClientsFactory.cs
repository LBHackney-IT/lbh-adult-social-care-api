using BaseApi.V1.Boundary.Request;
using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;

namespace BaseApi.V1.Factories
{
    public static class ClientsFactory
    {
        public static ClientsDomain ToDomain(Clients clientsEntity)
        {
            return new ClientsDomain()
            {
                Id = clientsEntity.Id,
                FirstName = clientsEntity.FirstName,
                MiddleName = clientsEntity.MiddleName,
                LastName = clientsEntity.LastName,
                DateOfBirth = clientsEntity.DateOfBirth,
                HackneyId = clientsEntity.HackneyId,
                AddressLine1 = clientsEntity.AddressLine1,
                AddressLine2 = clientsEntity.AddressLine2,
                AddressLine3 = clientsEntity.AddressLine3,
                Town = clientsEntity.Town,
                County = clientsEntity.County,
                PostCode = clientsEntity.PostCode,
                CreatorId = clientsEntity.CreatorId,
                DateCreated = clientsEntity.DateCreated,
                UpdatorId = clientsEntity.UpdatorId,
                DateUpdated = clientsEntity.DateUpdated
            };
        }

        public static Clients ToEntity(ClientsDomain clientsDomain)
        {
            return new Clients()
            {
                Id = clientsDomain.Id,
                FirstName = clientsDomain.FirstName,
                MiddleName = clientsDomain.MiddleName,
                LastName = clientsDomain.LastName,
                DateOfBirth = clientsDomain.DateOfBirth,
                HackneyId = clientsDomain.HackneyId,
                AddressLine1 = clientsDomain.AddressLine1,
                AddressLine2 = clientsDomain.AddressLine2,
                AddressLine3 = clientsDomain.AddressLine3,
                Town = clientsDomain.Town,
                County = clientsDomain.County,
                PostCode = clientsDomain.PostCode,
                CreatorId = clientsDomain.CreatorId,
                DateCreated = clientsDomain.DateCreated,
                UpdatorId = clientsDomain.UpdatorId,
                DateUpdated = clientsDomain.DateUpdated
            };
        }

        public static ClientsResponse ToResponse(ClientsDomain clientsDomain)
        {
            return new ClientsResponse()
            {
                Id = clientsDomain.Id,
                FirstName = clientsDomain.FirstName,
                MiddleName = clientsDomain.MiddleName,
                LastName = clientsDomain.LastName,
                DateOfBirth = clientsDomain.DateOfBirth,
                HackneyId = clientsDomain.HackneyId,
                AddressLine1 = clientsDomain.AddressLine1,
                AddressLine2 = clientsDomain.AddressLine2,
                AddressLine3 = clientsDomain.AddressLine3,
                Town = clientsDomain.Town,
                County = clientsDomain.County,
                PostCode = clientsDomain.PostCode,
                CreatorId = clientsDomain.CreatorId,
                DateCreated = clientsDomain.DateCreated,
                UpdatorId = clientsDomain.UpdatorId,
                DateUpdated = clientsDomain.DateUpdated
            };
        }

        public static ClientsDomain ToDomain(ClientsRequest clientsEntity)
        {
            return new ClientsDomain()
            {
                Id = clientsEntity.Id,
                FirstName = clientsEntity.FirstName,
                MiddleName = clientsEntity.MiddleName,
                LastName = clientsEntity.LastName,
                DateOfBirth = clientsEntity.DateOfBirth,
                HackneyId = clientsEntity.HackneyId,
                AddressLine1 = clientsEntity.AddressLine1,
                AddressLine2 = clientsEntity.AddressLine2,
                AddressLine3 = clientsEntity.AddressLine3,
                Town = clientsEntity.Town,
                County = clientsEntity.County,
                PostCode = clientsEntity.PostCode,
                CreatorId = clientsEntity.CreatorId,
                DateCreated = clientsEntity.DateCreated,
                UpdatorId = clientsEntity.UpdatorId,
                DateUpdated = clientsEntity.DateUpdated
            };
        }
    }
}
