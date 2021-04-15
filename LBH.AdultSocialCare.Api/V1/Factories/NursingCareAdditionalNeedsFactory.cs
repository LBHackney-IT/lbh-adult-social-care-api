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
    public static class NursingCareAdditionalNeedsFactory
    {
        public static NursingCareAdditionalNeedsDomain ToDomain(NursingCareAdditionalNeeds nursingCareAdditionalNeedsEntity)
        {
            return new NursingCareAdditionalNeedsDomain
            {
                Id = nursingCareAdditionalNeedsEntity.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsEntity.NursingCarePackageId,
                Weekly = nursingCareAdditionalNeedsEntity.Weekly,
                OneOff = nursingCareAdditionalNeedsEntity.OneOff,
                NeedToAddress = nursingCareAdditionalNeedsEntity.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsEntity.CreatorId,
                UpdatorId = nursingCareAdditionalNeedsEntity.UpdatorId,
            };
        }

        public static NursingCareAdditionalNeeds ToEntity(NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain)
        {
            return new NursingCareAdditionalNeeds
            {
                Id = nursingCareAdditionalNeedsDomain.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsDomain.NursingCarePackageId,
                Weekly = nursingCareAdditionalNeedsDomain.Weekly,
                OneOff = nursingCareAdditionalNeedsDomain.OneOff,
                NeedToAddress = nursingCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsDomain.CreatorId,
                UpdatorId = nursingCareAdditionalNeedsDomain.UpdatorId,
            };
        }

        public static NursingCareAdditionalNeedsResponse ToResponse(NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain)
        {
            return new NursingCareAdditionalNeedsResponse
            {
                Id = nursingCareAdditionalNeedsDomain.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsDomain.NursingCarePackageId,
                Weekly = nursingCareAdditionalNeedsDomain.Weekly,
                OneOff = nursingCareAdditionalNeedsDomain.OneOff,
                NeedToAddress = nursingCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsDomain.CreatorId,
                UpdatorId = nursingCareAdditionalNeedsDomain.UpdatorId,
            };
        }

        public static NursingCareAdditionalNeedsDomain ToDomain(NursingCareAdditionalNeedsRequest nursingCareAdditionalNeedsEntity)
        {
            return new NursingCareAdditionalNeedsDomain
            {
                Id = nursingCareAdditionalNeedsEntity.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsEntity.NursingCarePackageId,
                Weekly = nursingCareAdditionalNeedsEntity.Weekly,
                OneOff = nursingCareAdditionalNeedsEntity.OneOff,
                NeedToAddress = nursingCareAdditionalNeedsEntity.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsEntity.CreatorId,
                UpdatorId = nursingCareAdditionalNeedsEntity.UpdatorId,
            };
        }
    }
}
