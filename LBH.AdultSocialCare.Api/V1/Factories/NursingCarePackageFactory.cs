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
    public static class NursingCarePackageFactory
    {
        public static NursingCarePackageDomain ToDomain(NursingCarePackage nursingCarePackageEntity)
        {
            return new NursingCarePackageDomain
            {
                Id = nursingCarePackageEntity.Id,
                ClientId = nursingCarePackageEntity.ClientId,
                Clients = nursingCarePackageEntity.Clients,
                StartDate = nursingCarePackageEntity.StartDate,
                EndDate = nursingCarePackageEntity.EndDate,
                IsInterim = nursingCarePackageEntity.IsInterim,
                IsUnder8Weeks = nursingCarePackageEntity.IsUnder8Weeks,
                IsUnder52Weeks = nursingCarePackageEntity.IsUnder52Weeks,
                IsLongStay = nursingCarePackageEntity.IsLongStay,
                NeedToAddress = nursingCarePackageEntity.NeedToAddress,
                TypeOfNursingHome = nursingCarePackageEntity.TypeOfNursingHome,
                CreatorId = nursingCarePackageEntity.CreatorId,
                UpdatorId = nursingCarePackageEntity.UpdatorId,
                StatusId = nursingCarePackageEntity.StatusId,
                Status = nursingCarePackageEntity.Status,
                NursingCareAdditionalNeeds = nursingCarePackageEntity.NursingCareAdditionalNeeds
            };
        }

        public static NursingCarePackage ToEntity(NursingCarePackageDomain nursingCarePackageDomain)
        {
            return new NursingCarePackage
            {
                Id = nursingCarePackageDomain.Id,
                ClientId = nursingCarePackageDomain.ClientId,
                Clients = nursingCarePackageDomain.Clients,
                StartDate = nursingCarePackageDomain.StartDate,
                EndDate = nursingCarePackageDomain.EndDate,
                IsInterim = nursingCarePackageDomain.IsInterim,
                IsUnder8Weeks = nursingCarePackageDomain.IsUnder8Weeks,
                IsUnder52Weeks = nursingCarePackageDomain.IsUnder52Weeks,
                IsLongStay = nursingCarePackageDomain.IsLongStay,
                NeedToAddress = nursingCarePackageDomain.NeedToAddress,
                TypeOfNursingHome = nursingCarePackageDomain.TypeOfNursingHome,
                CreatorId = nursingCarePackageDomain.CreatorId,
                UpdatorId = nursingCarePackageDomain.UpdatorId,
                StatusId = nursingCarePackageDomain.StatusId,
                Status = nursingCarePackageDomain.Status,
                NursingCareAdditionalNeeds = nursingCarePackageDomain.NursingCareAdditionalNeeds
            };
        }

        public static NursingCarePackageResponse ToResponse(NursingCarePackageDomain nursingCarePackageDomain)
        {
            return new NursingCarePackageResponse
            {
                Id = nursingCarePackageDomain.Id,
                ClientId = nursingCarePackageDomain.ClientId,
                Clients = nursingCarePackageDomain.Clients,
                StartDate = nursingCarePackageDomain.StartDate,
                EndDate = nursingCarePackageDomain.EndDate,
                IsInterim = nursingCarePackageDomain.IsInterim,
                IsUnder8Weeks = nursingCarePackageDomain.IsUnder8Weeks,
                IsUnder52Weeks = nursingCarePackageDomain.IsUnder52Weeks,
                IsLongStay = nursingCarePackageDomain.IsLongStay,
                NeedToAddress = nursingCarePackageDomain.NeedToAddress,
                TypeOfNursingHome = nursingCarePackageDomain.TypeOfNursingHome,
                CreatorId = nursingCarePackageDomain.CreatorId,
                UpdatorId = nursingCarePackageDomain.UpdatorId,
                StatusId = nursingCarePackageDomain.StatusId,
                Status = nursingCarePackageDomain.Status,
                NursingCareAdditionalNeeds = nursingCarePackageDomain.NursingCareAdditionalNeeds
            };
        }

        public static NursingCarePackageDomain ToDomain(NursingCarePackageRequest nursingCarePackageRequest)
        {
            return new NursingCarePackageDomain
            {
                Id = nursingCarePackageRequest.Id,
                ClientId = nursingCarePackageRequest.ClientId,
                StartDate = nursingCarePackageRequest.StartDate,
                EndDate = nursingCarePackageRequest.EndDate,
                IsInterim = nursingCarePackageRequest.IsInterim,
                IsUnder8Weeks = nursingCarePackageRequest.IsUnder8Weeks,
                IsUnder52Weeks = nursingCarePackageRequest.IsUnder52Weeks,
                IsLongStay = nursingCarePackageRequest.IsLongStay,
                NeedToAddress = nursingCarePackageRequest.NeedToAddress,
                TypeOfNursingHome = nursingCarePackageRequest.TypeOfNursingHome,
                CreatorId = nursingCarePackageRequest.CreatorId,
                UpdatorId = nursingCarePackageRequest.UpdatorId,
                StatusId = nursingCarePackageRequest.StatusId
            };
        }
    }
}
