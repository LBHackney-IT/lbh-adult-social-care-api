using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;

namespace BaseApi.V1.Factories
{
    public static class PackageFactory
    {
        public static PackageDomain ToDomain(Package packageEntity)
        {
            return new PackageDomain()
            {
                Id = packageEntity.Id,
                PackageName = packageEntity.PackageName,
                Sequence = packageEntity.Sequence,
                CreatorId = packageEntity.CreatorId,
                DateCreated = packageEntity.DateCreated,
                UpdatorId = packageEntity.UpdatorId,
                DateUpdated = packageEntity.DateUpdated,
                Success = packageEntity.Success,
                Message = packageEntity.Message
            };
        }

        public static Package ToEntity(PackageDomain packageDomain)
        {
            return new Package()
            {
                Id = packageDomain.Id,
                PackageName = packageDomain.PackageName,
                Sequence = packageDomain.Sequence,
                CreatorId = packageDomain.CreatorId,
                DateCreated = packageDomain.DateCreated,
                UpdatorId = packageDomain.UpdatorId,
                DateUpdated = packageDomain.DateUpdated,
                Success = packageDomain.Success,
                Message = packageDomain.Message
            };
        }

        public static PackageResponse ToResponse(PackageDomain packageDomain)
        {
            return new PackageResponse()
            {
                Id = packageDomain.Id,
                PackageName = packageDomain.PackageName,
                Sequence = packageDomain.Sequence,
                CreatorId = packageDomain.CreatorId,
                DateCreated = packageDomain.DateCreated,
                UpdatorId = packageDomain.UpdatorId,
                DateUpdated = packageDomain.DateUpdated,
                Success = packageDomain.Success,
                Message = packageDomain.Message
            };
        }

        public static PackageDomain ToDomain(PackageResponse packageEntity)
        {
            return new PackageDomain()
            {
                Id = packageEntity.Id,
                PackageName = packageEntity.PackageName,
                Sequence = packageEntity.Sequence,
                CreatorId = packageEntity.CreatorId,
                DateCreated = packageEntity.DateCreated,
                UpdatorId = packageEntity.UpdatorId,
                DateUpdated = packageEntity.DateUpdated,
                Success = packageEntity.Success,
                Message = packageEntity.Message
            };
        }
    }
}
