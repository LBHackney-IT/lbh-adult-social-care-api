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
    public static class ResidentialCarePackageFactory
    {
        public static ResidentialCarePackageDomain ToDomain(ResidentialCarePackage residentialCarePackageEntity)
        {
            return new ResidentialCarePackageDomain
            {
                Id = residentialCarePackageEntity.Id,
                ClientId = residentialCarePackageEntity.ClientId,
                Clients = residentialCarePackageEntity.Clients,
                StartDate = residentialCarePackageEntity.StartDate,
                EndDate = residentialCarePackageEntity.EndDate,
                IsRespiteCare = residentialCarePackageEntity.IsRespiteCare,
                IsDischargePackage = residentialCarePackageEntity.IsDischargePackage,
                IsImmediateReenablementPackage = residentialCarePackageEntity.IsImmediateReenablementPackage,
                IsExpectedStayOver52Weeks = residentialCarePackageEntity.IsExpectedStayOver52Weeks,
                IsThisUserUnderS117 = residentialCarePackageEntity.IsThisUserUnderS117,
                NeedToAddress = residentialCarePackageEntity.NeedToAddress,
                TypeOfCareHome = residentialCarePackageEntity.TypeOfCareHome,
                CreatorId = residentialCarePackageEntity.CreatorId,
                UpdatorId = residentialCarePackageEntity.UpdatorId,
                StatusId = residentialCarePackageEntity.StatusId,
                Status = residentialCarePackageEntity.Status,
                ResidentialCareAdditionalNeeds = residentialCarePackageEntity.ResidentialCareAdditionalNeeds
            };
        }

        public static ResidentialCarePackage ToEntity(ResidentialCarePackageDomain residentialCarePackageDomain)
        {
            return new ResidentialCarePackage
            {
                Id = residentialCarePackageDomain.Id,
                ClientId = residentialCarePackageDomain.ClientId,
                Clients = residentialCarePackageDomain.Clients,
                StartDate = residentialCarePackageDomain.StartDate,
                EndDate = residentialCarePackageDomain.EndDate,
                IsRespiteCare = residentialCarePackageDomain.IsRespiteCare,
                IsDischargePackage = residentialCarePackageDomain.IsDischargePackage,
                IsImmediateReenablementPackage = residentialCarePackageDomain.IsImmediateReenablementPackage,
                IsExpectedStayOver52Weeks = residentialCarePackageDomain.IsExpectedStayOver52Weeks,
                IsThisUserUnderS117 = residentialCarePackageDomain.IsThisUserUnderS117,
                NeedToAddress = residentialCarePackageDomain.NeedToAddress,
                TypeOfCareHome = residentialCarePackageDomain.TypeOfCareHome,
                CreatorId = residentialCarePackageDomain.CreatorId,
                UpdatorId = residentialCarePackageDomain.UpdatorId,
                StatusId = residentialCarePackageDomain.StatusId,
                Status = residentialCarePackageDomain.Status,
                ResidentialCareAdditionalNeeds = residentialCarePackageDomain.ResidentialCareAdditionalNeeds
            };
        }

        public static ResidentialCarePackageResponse ToResponse(ResidentialCarePackageDomain residentialCarePackageDomain)
        {
            return new ResidentialCarePackageResponse
            {
                Id = residentialCarePackageDomain.Id,
                ClientId = residentialCarePackageDomain.ClientId,
                Clients = residentialCarePackageDomain.Clients,
                StartDate = residentialCarePackageDomain.StartDate,
                EndDate = residentialCarePackageDomain.EndDate,
                IsRespiteCare = residentialCarePackageDomain.IsRespiteCare,
                IsDischargePackage = residentialCarePackageDomain.IsDischargePackage,
                IsImmediateReenablementPackage = residentialCarePackageDomain.IsImmediateReenablementPackage,
                IsExpectedStayOver52Weeks = residentialCarePackageDomain.IsExpectedStayOver52Weeks,
                IsThisUserUnderS117 = residentialCarePackageDomain.IsThisUserUnderS117,
                NeedToAddress = residentialCarePackageDomain.NeedToAddress,
                TypeOfCareHome = residentialCarePackageDomain.TypeOfCareHome,
                CreatorId = residentialCarePackageDomain.CreatorId,
                UpdatorId = residentialCarePackageDomain.UpdatorId,
                StatusId = residentialCarePackageDomain.StatusId,
                Status = residentialCarePackageDomain.Status,
                ResidentialCareAdditionalNeeds = residentialCarePackageDomain.ResidentialCareAdditionalNeeds
            };
        }

        public static ResidentialCarePackageDomain ToDomain(ResidentialCarePackageRequest residentialCarePackageRequest)
        {
            return new ResidentialCarePackageDomain
            {
                Id = residentialCarePackageRequest.Id,
                ClientId = residentialCarePackageRequest.ClientId,
                StartDate = residentialCarePackageRequest.StartDate,
                EndDate = residentialCarePackageRequest.EndDate,
                IsRespiteCare = residentialCarePackageRequest.IsRespiteCare,
                IsDischargePackage = residentialCarePackageRequest.IsDischargePackage,
                IsImmediateReenablementPackage = residentialCarePackageRequest.IsImmediateReenablementPackage,
                IsExpectedStayOver52Weeks = residentialCarePackageRequest.IsExpectedStayOver52Weeks,
                IsThisUserUnderS117 = residentialCarePackageRequest.IsThisUserUnderS117,
                NeedToAddress = residentialCarePackageRequest.NeedToAddress,
                TypeOfCareHome = residentialCarePackageRequest.TypeOfCareHome,
                CreatorId = residentialCarePackageRequest.CreatorId,
                UpdatorId = residentialCarePackageRequest.UpdatorId,
                StatusId = residentialCarePackageRequest.StatusId
            };
        }
    }
}
