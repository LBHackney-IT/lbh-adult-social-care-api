using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ServiceFactory
    {
        public static ServiceDomain ToDomain(PackageServices serviceEntity)
        {
            return new ServiceDomain
            {
                Id = serviceEntity.Id,
                ServiceName = serviceEntity.ServiceName,
                PackageId = serviceEntity.PackageId,
                Package = serviceEntity.Package,
                CreatorId = serviceEntity.CreatorId,
                DateCreated = serviceEntity.DateCreated,
                UpdatorId = serviceEntity.UpdatorId,
                DateUpdated = serviceEntity.DateUpdated
            };
        }

        public static PackageServices ToEntity(ServiceDomain serviceDomain)
        {
            return new PackageServices
            {
                Id = serviceDomain.Id,
                ServiceName = serviceDomain.ServiceName,
                PackageId = serviceDomain.PackageId,
                Package = serviceDomain.Package,
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
