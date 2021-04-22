using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareAdditionalNeedsBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

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
                IsWeeklyCost = nursingCareAdditionalNeedsEntity.IsWeeklyCost,
                IsOneOffCost = nursingCareAdditionalNeedsEntity.IsOneOffCost,
                NeedToAddress = nursingCareAdditionalNeedsEntity.NeedToAddress,
                CreatorId = nursingCareAdditionalNeedsEntity.CreatorId,
                UpdaterId = nursingCareAdditionalNeedsEntity.UpdaterId,
            };
        }

        public static NursingCareAdditionalNeeds ToEntity(NursingCareAdditionalNeedsDomain nursingCareAdditionalNeedsDomain)
        {
            return new NursingCareAdditionalNeeds
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
