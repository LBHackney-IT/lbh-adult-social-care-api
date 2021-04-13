using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class PackageFactory
    {
        public static PackageDomain ToDomain(Package packageEntity)
        {
            return new PackageDomain
            {
                Id = packageEntity.Id,
                PackageName = packageEntity.PackageName,
                Sequence = packageEntity.Sequence,
                CreatorId = packageEntity.CreatorId,
                DateCreated = packageEntity.DateCreated,
                UpdatorId = packageEntity.UpdatorId,
                DateUpdated = packageEntity.DateUpdated
            };
        }

        public static Package ToEntity(PackageDomain packageDomain)
        {
            return new Package
            {
                Id = packageDomain.Id,
                PackageName = packageDomain.PackageName,
                Sequence = packageDomain.Sequence,
                CreatorId = packageDomain.CreatorId,
                UpdatorId = packageDomain.UpdatorId
            };
        }

        public static PackageResponse ToResponse(PackageDomain packageDomain)
        {
            return new PackageResponse
            {
                Id = packageDomain.Id,
                PackageName = packageDomain.PackageName,
                Sequence = packageDomain.Sequence,
                CreatorId = packageDomain.CreatorId,
                DateCreated = packageDomain.DateCreated,
                UpdatorId = packageDomain.UpdatorId,
                DateUpdated = packageDomain.DateUpdated
            };
        }

        public static PackageDomain ToDomain(PackageRequest packageEntity)
        {
            return new PackageDomain
            {
                Id = packageEntity.Id,
                PackageName = packageEntity.PackageName,
                CreatorId = packageEntity.CreatorId,
                DateCreated = packageEntity.DateCreated,
                UpdatorId = packageEntity.UpdatorId,
                DateUpdated = packageEntity.DateUpdated
            };
        }
    }
}
