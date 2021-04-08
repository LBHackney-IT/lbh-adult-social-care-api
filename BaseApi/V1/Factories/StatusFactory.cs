using BaseApi.V1.Boundary.Request;
using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;

namespace BaseApi.V1.Factories
{
    public static class StatusFactory
    {
        public static StatusDomain ToDomain(Status statusEntity)
        {
            return new StatusDomain()
            {
                Id = statusEntity.Id,
                StatusName = statusEntity.StatusName,
                CreatorId = statusEntity.CreatorId,
                DateCreated = statusEntity.DateCreated,
                UpdatorId = statusEntity.UpdatorId,
                DateUpdated = statusEntity.DateUpdated
            };
        }

        public static Status ToEntity(StatusDomain statusDomain)
        {
            return new Status()
            {
                Id = statusDomain.Id,
                StatusName = statusDomain.StatusName,
                CreatorId = statusDomain.CreatorId,
                DateCreated = statusDomain.DateCreated,
                UpdatorId = statusDomain.UpdatorId,
                DateUpdated = statusDomain.DateUpdated
            };
        }

        public static StatusResponse ToResponse(StatusDomain statusDomain)
        {
            return new StatusResponse()
            {
                Id = statusDomain.Id,
                StatusName = statusDomain.StatusName,
                CreatorId = statusDomain.CreatorId,
                DateCreated = statusDomain.DateCreated,
                UpdatorId = statusDomain.UpdatorId,
                DateUpdated = statusDomain.DateUpdated
            };
        }

        public static StatusDomain ToDomain(StatusRequest statusEntity)
        {
            return new StatusDomain()
            {
                Id = statusEntity.Id,
                StatusName = statusEntity.StatusName,
                CreatorId = statusEntity.CreatorId,
                DateCreated = statusEntity.DateCreated,
                UpdatorId = statusEntity.UpdatorId,
                DateUpdated = statusEntity.DateUpdated
            };
        }
    }
}
