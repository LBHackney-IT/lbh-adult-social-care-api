using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class StatusFactory
    {
        public static StatusDomain ToDomain(PackageStatus statusEntity)
        {
            return new StatusDomain
            {
                Id = statusEntity.Id,
                StatusName = statusEntity.StatusName,
                CreatorId = statusEntity.CreatorId,
                UpdaterId = statusEntity.UpdaterId
            };
        }

        public static PackageStatus ToEntity(StatusDomain statusDomain)
        {
            return new PackageStatus
            {
                Id = statusDomain.Id,
                StatusName = statusDomain.StatusName,
                CreatorId = statusDomain.CreatorId,
                UpdaterId = statusDomain.UpdaterId
            };
        }

        public static StatusResponse ToResponse(StatusDomain statusDomain)
        {
            return new StatusResponse
            {
                Id = statusDomain.Id,
                StatusName = statusDomain.StatusName,
                CreatorId = statusDomain.CreatorId,
                UpdaterId = statusDomain.UpdaterId
            };
        }

        public static StatusDomain ToDomain(StatusRequest statusEntity)
        {
            return new StatusDomain
            {
                Id = statusEntity.Id,
                StatusName = statusEntity.StatusName,
                CreatorId = statusEntity.CreatorId,
                UpdaterId = statusEntity.UpdaterId
            };
        }
    }
}
