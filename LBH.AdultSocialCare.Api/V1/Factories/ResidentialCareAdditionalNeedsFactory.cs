using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCarePackageBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ResidentialCareAdditionalNeedsFactory
    {
        public static ResidentialCareAdditionalNeedsDomain ToDomain(ResidentialCareAdditionalNeed residentialCareAdditionalNeedEntity)
        {
            return new ResidentialCareAdditionalNeedsDomain
            {
                Id = residentialCareAdditionalNeedEntity.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedEntity.ResidentialCarePackageId,
                IsWeeklyCost = residentialCareAdditionalNeedEntity.IsWeeklyCost,
                IsOneOffCost = residentialCareAdditionalNeedEntity.IsOneOffCost,
                NeedToAddress = residentialCareAdditionalNeedEntity.NeedToAddress,
                CreatorId = residentialCareAdditionalNeedEntity.CreatorId,
                UpdatorId = residentialCareAdditionalNeedEntity.UpdaterId,
            };
        }

        public static ResidentialCareAdditionalNeed ToEntity(ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeedsDomain)
        {
            return new ResidentialCareAdditionalNeed
            {
                Id = residentialCareAdditionalNeedsDomain.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsDomain.ResidentialCarePackageId,
                IsWeeklyCost = residentialCareAdditionalNeedsDomain.IsWeeklyCost,
                IsOneOffCost = residentialCareAdditionalNeedsDomain.IsOneOffCost,
                NeedToAddress = residentialCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = residentialCareAdditionalNeedsDomain.CreatorId,
                UpdaterId = residentialCareAdditionalNeedsDomain.UpdatorId,
            };
        }

        public static ResidentialCareAdditionalNeedsResponse ToResponse(ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeedsDomain)
        {
            return new ResidentialCareAdditionalNeedsResponse
            {
                Id = residentialCareAdditionalNeedsDomain.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsDomain.ResidentialCarePackageId,
                IsWeeklyCost = residentialCareAdditionalNeedsDomain.IsWeeklyCost,
                IsOneOffCost = residentialCareAdditionalNeedsDomain.IsOneOffCost,
                NeedToAddress = residentialCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = residentialCareAdditionalNeedsDomain.CreatorId,
                UpdatorId = residentialCareAdditionalNeedsDomain.UpdatorId,
            };
        }

        public static ResidentialCareAdditionalNeedsDomain ToDomain(ResidentialCareAdditionalNeedsRequest residentialCareAdditionalNeedsEntity)
        {
            return new ResidentialCareAdditionalNeedsDomain
            {
                Id = residentialCareAdditionalNeedsEntity.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsEntity.ResidentialCarePackageId,
                IsWeeklyCost = residentialCareAdditionalNeedsEntity.IsWeeklyCost,
                IsOneOffCost = residentialCareAdditionalNeedsEntity.IsOneOffCost,
                NeedToAddress = residentialCareAdditionalNeedsEntity.NeedToAddress,
            };
        }
    }
}
