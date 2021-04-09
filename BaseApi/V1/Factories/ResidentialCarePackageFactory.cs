using BaseApi.V1.Boundary.Request;
using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Factories
{
    public static class ResidentialCarePackageFactory
    {
        public static ResidentialCarePackageDomain ToDomain(ResidentialCarePackage residentialCarePackageEntity)
        {
            return new ResidentialCarePackageDomain()
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
                Weekly = residentialCarePackageEntity.Weekly,
                OneOff = residentialCarePackageEntity.OneOff,
                AdditionalNeedToAddress = residentialCarePackageEntity.AdditionalNeedToAddress,
                CreatorId = residentialCarePackageEntity.CreatorId,
                DateCreated = residentialCarePackageEntity.DateCreated,
                UpdatorId = residentialCarePackageEntity.UpdatorId,
                DateUpdated = residentialCarePackageEntity.DateUpdated,
                StatusId = residentialCarePackageEntity.StatusId,
                Status = residentialCarePackageEntity.Status
            };
        }

        public static ResidentialCarePackage ToEntity(ResidentialCarePackageDomain residentialCarePackageDomain)
        {
            return new ResidentialCarePackage()
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
                Weekly = residentialCarePackageDomain.Weekly,
                OneOff = residentialCarePackageDomain.OneOff,
                AdditionalNeedToAddress = residentialCarePackageDomain.AdditionalNeedToAddress,
                CreatorId = residentialCarePackageDomain.CreatorId,
                DateCreated = residentialCarePackageDomain.DateCreated,
                UpdatorId = residentialCarePackageDomain.UpdatorId,
                DateUpdated = residentialCarePackageDomain.DateUpdated,
                StatusId = residentialCarePackageDomain.StatusId,
                Status = residentialCarePackageDomain.Status
            };
        }

        public static ResidentialCarePackageResponse ToResponse(ResidentialCarePackageDomain residentialCarePackageDomain)
        {
            return new ResidentialCarePackageResponse()
            {
                Id = residentialCarePackageDomain.Id,
                PackageId = residentialCarePackageDomain.PackageId,
                Package = residentialCarePackageDomain.Package,
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
                Weekly = residentialCarePackageDomain.Weekly,
                OneOff = residentialCarePackageDomain.OneOff,
                AdditionalNeedToAddress = residentialCarePackageDomain.AdditionalNeedToAddress,
                CreatorId = residentialCarePackageDomain.CreatorId,
                DateCreated = residentialCarePackageDomain.DateCreated,
                UpdatorId = residentialCarePackageDomain.UpdatorId,
                DateUpdated = residentialCarePackageDomain.DateUpdated,
                StatusId = residentialCarePackageDomain.StatusId,
                Status = residentialCarePackageDomain.Status
            };
        }

        public static ResidentialCarePackageDomain ToDomain(ResidentialCarePackageRequest residentialCarePackageRequest)
        {
            return new ResidentialCarePackageDomain()
            {
                Id = residentialCarePackageRequest.Id,
                PackageId = residentialCarePackageRequest.PackageId,
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
                Weekly = residentialCarePackageRequest.Weekly,
                OneOff = residentialCarePackageRequest.OneOff,
                AdditionalNeedToAddress = residentialCarePackageRequest.AdditionalNeedToAddress,
                CreatorId = residentialCarePackageRequest.CreatorId,
                DateCreated = residentialCarePackageRequest.DateCreated,
                UpdatorId = residentialCarePackageRequest.UpdatorId,
                DateUpdated = residentialCarePackageRequest.DateUpdated,
                StatusId = residentialCarePackageRequest.StatusId
            };
        }
    }
}
