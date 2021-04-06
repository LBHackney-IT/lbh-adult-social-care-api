using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Factories
{
    public static class ServiceFactory
    {
        public static ServiceDomain ToDomain(PackageServices serviceEntity)
        {
            return new ServiceDomain()
            {
                Id = serviceEntity.Id,
                ServiceName = serviceEntity.ServiceName,
                PackageId = serviceEntity.PackageId,
                Package = serviceEntity.Package,
                CreatorId = serviceEntity.CreatorId,
                DateCreated = serviceEntity.DateCreated,
                UpdatorId = serviceEntity.UpdatorId,
                DateUpdated = serviceEntity.DateUpdated,
                Success = serviceEntity.Success,
                Message = serviceEntity.Message
            };
        }

        public static PackageServices ToEntity(ServiceDomain serviceDomain)
        {
            return new PackageServices()
            {
                Id = serviceDomain.Id,
                ServiceName = serviceDomain.ServiceName,
                PackageId = serviceDomain.PackageId,
                Package = serviceDomain.Package,
                CreatorId = serviceDomain.CreatorId,
                DateCreated = serviceDomain.DateCreated,
                UpdatorId = serviceDomain.UpdatorId,
                DateUpdated = serviceDomain.DateUpdated,
                Success = serviceDomain.Success,
                Message = serviceDomain.Message
            };
        }

        public static ServiceResponse ToResponse(ServiceDomain serviceDomain)
        {
            return new ServiceResponse()
            {
                Id = serviceDomain.Id,
                ServiceName = serviceDomain.ServiceName,
                PackageId = serviceDomain.PackageId,
                Package = serviceDomain.Package,
                CreatorId = serviceDomain.CreatorId,
                DateCreated = serviceDomain.DateCreated,
                UpdatorId = serviceDomain.UpdatorId,
                DateUpdated = serviceDomain.DateUpdated,
                Success = serviceDomain.Success,
                Message = serviceDomain.Message
            };
        }

        public static ServiceDomain ToDomain(ServiceResponse serviceEntity)
        {
            return new ServiceDomain()
            {
                Id = serviceEntity.Id,
                ServiceName = serviceEntity.ServiceName,
                PackageId = serviceEntity.PackageId,
                Package = serviceEntity.Package,
                CreatorId = serviceEntity.CreatorId,
                DateCreated = serviceEntity.DateCreated,
                UpdatorId = serviceEntity.UpdatorId,
                DateUpdated = serviceEntity.DateUpdated,
                Success = serviceEntity.Success,
                Message = serviceEntity.Message
            };
        }
    }
}
