using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class NursingCareAdditionalNeedsFactory
    {
        public static NursingCareAdditionalNeedsDomain ToDomain(NursingCareAdditionalNeed nursingCareAdditionalNeedEntity)
        {
            return new NursingCareAdditionalNeedsDomain
            {
                Id = nursingCareAdditionalNeedEntity.Id,
                NursingCarePackageId = nursingCareAdditionalNeedEntity.NursingCarePackageId,
                IsWeeklyCost = nursingCareAdditionalNeedEntity.IsWeeklyCost,
                IsOneOffCost = nursingCareAdditionalNeedEntity.IsOneOffCost,
                NeedToAddress = nursingCareAdditionalNeedEntity.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedEntity.CreatorId,
                UpdaterId = nursingCareAdditionalNeedEntity.UpdaterId,
            };
        }

        public static NursingCareAdditionalNeed ToEntity(NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain)
        {
            return new NursingCareAdditionalNeed
            {
                Id = nursingCareAdditionalNeedsDomain.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsDomain.NursingCarePackageId,
                IsWeeklyCost = nursingCareAdditionalNeedsDomain.IsWeeklyCost,
                IsOneOffCost = nursingCareAdditionalNeedsDomain.IsOneOffCost,
                NeedToAddress = nursingCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsDomain.CreatorId,
                UpdaterId = nursingCareAdditionalNeedsDomain.UpdaterId,
            };
        }

        public static NursingCareAdditionalNeedsResponse ToResponse(NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain)
        {
            return new NursingCareAdditionalNeedsResponse
            {
                Id = nursingCareAdditionalNeedsDomain.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsDomain.NursingCarePackageId,
                IsWeeklyCost = nursingCareAdditionalNeedsDomain.IsWeeklyCost,
                IsOneOffCost = nursingCareAdditionalNeedsDomain.IsOneOffCost,
                NeedToAddress = nursingCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsDomain.CreatorId,
                UpdatorId = nursingCareAdditionalNeedsDomain.UpdaterId,
            };
        }

        public static NursingCareAdditionalNeedsDomain ToDomain(NursingCareAdditionalNeedsRequest nursingCareAdditionalNeedsEntity)
        {
            return new NursingCareAdditionalNeedsDomain
            {
                Id = nursingCareAdditionalNeedsEntity.Id,
                NursingCarePackageId = nursingCareAdditionalNeedsEntity.NursingCarePackageId,
                IsWeeklyCost = nursingCareAdditionalNeedsEntity.IsWeeklyCost,
                IsOneOffCost = nursingCareAdditionalNeedsEntity.IsOneOffCost,
                NeedToAddress = nursingCareAdditionalNeedsEntity.NeedToAddress,
            };
        }
    }
}
