using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ResidentialCareAdditionalNeedsFactory
    {
        public static ResidentialCareAdditionalNeedsDomain ToDomain(ResidentialCareAdditionalNeeds residentialCareAdditionalNeedsEntity)
        {
            return new ResidentialCareAdditionalNeedsDomain
            {
                Id = residentialCareAdditionalNeedsEntity.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsEntity.ResidentialCarePackageId,
                Weekly = residentialCareAdditionalNeedsEntity.Weekly,
                OneOff = residentialCareAdditionalNeedsEntity.OneOff,
                CreatorId = residentialCareAdditionalNeedsEntity.CreatorId,
                UpdatorId = residentialCareAdditionalNeedsEntity.UpdatorId,
            };
        }

        public static ResidentialCareAdditionalNeeds ToEntity(ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeedsDomain)
        {
            return new ResidentialCareAdditionalNeeds
            {
                Id = residentialCareAdditionalNeedsDomain.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsDomain.ResidentialCarePackageId,
                Weekly = residentialCareAdditionalNeedsDomain.Weekly,
                OneOff = residentialCareAdditionalNeedsDomain.OneOff,
                CreatorId = residentialCareAdditionalNeedsDomain.CreatorId,
                UpdatorId = residentialCareAdditionalNeedsDomain.UpdatorId,
            };
        }

        public static ResidentialCareAdditionalNeedsResponse ToResponse(ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeedsDomain)
        {
            return new ResidentialCareAdditionalNeedsResponse
            {
                Id = residentialCareAdditionalNeedsDomain.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsDomain.ResidentialCarePackageId,
                Weekly = residentialCareAdditionalNeedsDomain.Weekly,
                OneOff = residentialCareAdditionalNeedsDomain.OneOff,
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
                Weekly = residentialCareAdditionalNeedsEntity.Weekly,
                OneOff = residentialCareAdditionalNeedsEntity.OneOff,
                CreatorId = residentialCareAdditionalNeedsEntity.CreatorId,
                UpdatorId = residentialCareAdditionalNeedsEntity.UpdatorId,
            };
        }
    }
}
