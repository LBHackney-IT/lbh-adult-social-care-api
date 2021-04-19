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
    public static class HomeCarePackageCostFactory
    {
        public static HomeCarePackageCostDomain ToDomain(HomeCarePackageCost homeCarePackageCostEntity)
        {
            return new HomeCarePackageCostDomain
            {
                Id = homeCarePackageCostEntity.Id,
                HomeCarePackageId = homeCarePackageCostEntity.HomeCarePackageId,
                ServiceId = homeCarePackageCostEntity.ServiceId,
                Services = homeCarePackageCostEntity.Services,
                CostPerHour = homeCarePackageCostEntity.CostPerHour,
                HoursPerWeek = homeCarePackageCostEntity.HoursPerWeek,
                TotalCost = homeCarePackageCostEntity.TotalCost,
                CreatorId = homeCarePackageCostEntity.CreatorId,
                UpdatorId = homeCarePackageCostEntity.UpdatorId
            };
        }

        public static HomeCarePackageCost ToEntity(HomeCarePackageCostDomain homeCarePackageCostDomain)
        {
            return new HomeCarePackageCost
            {
                Id = homeCarePackageCostDomain.Id,
                HomeCarePackageId = homeCarePackageCostDomain.HomeCarePackageId,
                ServiceId = homeCarePackageCostDomain.ServiceId,
                Services = homeCarePackageCostDomain.Services,
                CostPerHour = homeCarePackageCostDomain.CostPerHour,
                HoursPerWeek = homeCarePackageCostDomain.HoursPerWeek,
                TotalCost = homeCarePackageCostDomain.TotalCost,
                CreatorId = homeCarePackageCostDomain.CreatorId,
                UpdatorId = homeCarePackageCostDomain.UpdatorId
            };
        }

        public static HomeCarePackageCostResponse ToResponse(HomeCarePackageCostDomain homeCarePackageCostDomain)
        {
            return new HomeCarePackageCostResponse
            {
                Id = homeCarePackageCostDomain.Id,
                HomeCarePackageId = homeCarePackageCostDomain.HomeCarePackageId,
                ServiceId = homeCarePackageCostDomain.ServiceId,
                Services = homeCarePackageCostDomain.Services,
                CostPerHour = homeCarePackageCostDomain.CostPerHour,
                HoursPerWeek = homeCarePackageCostDomain.HoursPerWeek,
                TotalCost = homeCarePackageCostDomain.TotalCost,
                CreatorId = homeCarePackageCostDomain.CreatorId,
                UpdatorId = homeCarePackageCostDomain.UpdatorId
            };
        }

        public static HomeCarePackageCostDomain ToDomain(HomeCarePackageCostRequest homeCarePackageCostEntity)
        {
            return new HomeCarePackageCostDomain
            {
                Id = homeCarePackageCostEntity.Id,
                HomeCarePackageId = homeCarePackageCostEntity.HomeCarePackageId,
                ServiceId = homeCarePackageCostEntity.ServiceId,
                CostPerHour = homeCarePackageCostEntity.CostPerHour,
                HoursPerWeek = homeCarePackageCostEntity.HoursPerWeek,
                TotalCost = homeCarePackageCostEntity.TotalCost,
                CreatorId = homeCarePackageCostEntity.CreatorId,
                UpdatorId = homeCarePackageCostEntity.UpdatorId
            };
        }
    }
}
