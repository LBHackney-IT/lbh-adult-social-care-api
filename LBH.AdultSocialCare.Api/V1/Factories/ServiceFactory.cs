using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ServiceFactory
    {
        public static ServiceDomain ToDomain(HomeCareServiceType serviceEntity)
        {
            return new ServiceDomain
            {
                Id = serviceEntity.Id,
                ServiceName = serviceEntity.ServiceName,
                CreatorId = serviceEntity.CreatorId,
                DateCreated = serviceEntity.DateCreated,
                UpdatorId = serviceEntity.UpdatorId,
                DateUpdated = serviceEntity.DateUpdated
            };
        }

        public static HomeCareServiceType ToEntity(ServiceDomain serviceDomain)
        {
            return new HomeCareServiceType
            {
                Id = serviceDomain.Id,
                ServiceName = serviceDomain.ServiceName,
                CreatorId = serviceDomain.CreatorId,
                UpdatorId = serviceDomain.UpdatorId,
            };
        }

        public static ServiceResponse ToResponse(ServiceDomain serviceDomain)
        {
            return new ServiceResponse
            {
                Id = serviceDomain.Id,
                ServiceName = serviceDomain.ServiceName,
                PackageId = serviceDomain.PackageId,
                Package = serviceDomain.Package,
                CreatorId = serviceDomain.CreatorId,
                DateCreated = serviceDomain.DateCreated,
                UpdatorId = serviceDomain.UpdatorId,
                DateUpdated = serviceDomain.DateUpdated
            };
        }

        public static ServiceDomain ToDomain(ServiceRequest serviceEntity)
        {
            return new ServiceDomain
            {
                Id = serviceEntity.Id,
                ServiceName = serviceEntity.ServiceName,
                PackageId = serviceEntity.PackageId,
                CreatorId = serviceEntity.CreatorId,
                DateCreated = serviceEntity.DateCreated,
                UpdatorId = serviceEntity.UpdatorId,
                DateUpdated = serviceEntity.DateUpdated
            };
        }
    }
}
