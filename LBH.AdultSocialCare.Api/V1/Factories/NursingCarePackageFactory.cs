using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Response;
using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class NursingCarePackageFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static NursingCarePackageDomain ToDomain(NursingCarePackage nursingCarePackageEntity)
        {
            return new NursingCarePackageDomain
            {
                Id = nursingCarePackageEntity.Id,
                ClientId = nursingCarePackageEntity.ClientId,
                Clients = nursingCarePackageEntity.Clients,
                StartDate = nursingCarePackageEntity.StartDate,
                EndDate = nursingCarePackageEntity.EndDate,
                IsRespiteCare = nursingCarePackageEntity.IsRespiteCare,
                IsDischargePackage = nursingCarePackageEntity.IsDischargePackage,
                IsThisAnImmediateService = nursingCarePackageEntity.IsThisAnImmediateService,
                IsThisUserUnderS117 = nursingCarePackageEntity.IsThisUserUnderS117,
                TypeOfStayId = nursingCarePackageEntity.TypeOfStayId,
                TypeOfStayOption = nursingCarePackageEntity.TypeOfStayOption,
                NeedToAddress = nursingCarePackageEntity.NeedToAddress,
                TypeOfNursingCareHomeId = nursingCarePackageEntity.TypeOfNursingCareHomeId,
                TypeOfCareHome = nursingCarePackageEntity.TypeOfCareHome,
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
                IsFixedPeriod = nursingCarePackageDomain.IsFixedPeriod,
                StartDate = nursingCarePackageDomain.StartDate,
                EndDate = nursingCarePackageDomain.EndDate,
                IsRespiteCare = nursingCarePackageDomain.IsRespiteCare,
                IsDischargePackage = nursingCarePackageDomain.IsDischargePackage,
                IsThisAnImmediateService = nursingCarePackageDomain.IsThisAnImmediateService,
                IsThisUserUnderS117 = nursingCarePackageDomain.IsThisUserUnderS117,
                TypeOfStayId = nursingCarePackageDomain.TypeOfStayId,
                TypeOfStayOption = nursingCarePackageDomain.TypeOfStayOption,
                NeedToAddress = nursingCarePackageDomain.NeedToAddress,
                TypeOfNursingCareHomeId = nursingCarePackageDomain.TypeOfNursingCareHomeId,
                TypeOfCareHome = nursingCarePackageDomain.TypeOfCareHome,
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
                IsFixedPeriod = nursingCarePackageDomain.IsFixedPeriod,
                StartDate = nursingCarePackageDomain.StartDate,
                EndDate = nursingCarePackageDomain.EndDate,
                IsRespiteCare = nursingCarePackageDomain.IsRespiteCare,
                IsDischargePackage = nursingCarePackageDomain.IsDischargePackage,
                IsThisAnImmediateService = nursingCarePackageDomain.IsThisAnImmediateService,
                IsThisUserUnderS117 = nursingCarePackageDomain.IsThisUserUnderS117,
                TypeOfStayId = nursingCarePackageDomain.TypeOfStayId,
                TypeOfStayOption = nursingCarePackageDomain.TypeOfStayOption,
                NeedToAddress = nursingCarePackageDomain.NeedToAddress,
                TypeOfNursingCareHomeId = nursingCarePackageDomain.TypeOfNursingCareHomeId,
                TypeOfCareHome = nursingCarePackageDomain.TypeOfCareHome,
                CreatorId = nursingCarePackageDomain.CreatorId,
                UpdatorId = nursingCarePackageDomain.UpdatorId,
                StatusId = nursingCarePackageDomain.StatusId,
                Status = nursingCarePackageDomain.Status,
                NursingCareAdditionalNeeds = nursingCarePackageDomain.NursingCareAdditionalNeeds
            };
        }

        public static NursingCarePackageDomain ToDomain(NursingCarePackageRequest nursingCarePackageRequest)
        {
            // Set status to 1 for new package
            if (nursingCarePackageRequest.StatusId == 0)
            {
                nursingCarePackageRequest.StatusId = 1;
            }

            return new NursingCarePackageDomain
            {
                Id = nursingCarePackageRequest.Id,
                ClientId = nursingCarePackageRequest.ClientId,
                IsFixedPeriod = nursingCarePackageRequest.IsFixedPeriod,
                StartDate = nursingCarePackageRequest.StartDate,
                EndDate = nursingCarePackageRequest.EndDate,
                IsRespiteCare = nursingCarePackageRequest.IsRespiteCare,
                IsDischargePackage = nursingCarePackageRequest.IsDischargePackage,
                IsThisAnImmediateService = nursingCarePackageRequest.IsThisAnImmediateService,
                IsThisUserUnderS117 = nursingCarePackageRequest.IsThisUserUnderS117,
                TypeOfStayId = nursingCarePackageRequest.TypeOfStayId,
                NeedToAddress = nursingCarePackageRequest.NeedToAddress,
                TypeOfNursingCareHomeId = nursingCarePackageRequest.TypeOfNursingCareHomeId,
                StatusId = nursingCarePackageRequest.StatusId
            };
        }

        public static IList<NursingCarePackageDomain> ToDomain(this IList<NursingCarePackage> nursingCarePackagesEntity)
        {
            return _mapper.Map<IList<NursingCarePackageDomain>>(nursingCarePackagesEntity);
        }

        public static IList<NursingCarePackageResponse> ToResponse(this IList<NursingCarePackageDomain> nursingCarePackagesDomain)
        {
            return _mapper.Map<IList<NursingCarePackageResponse>>(nursingCarePackagesDomain);
        }

        public static IList<TypeOfNursingCareHomeDomain> ToDomain(IList<TypeOfNursingCareHome> typeOfNursingCareHome)
        {
            return typeOfNursingCareHome.Select(item
             => new TypeOfNursingCareHomeDomain
             {
                 TypeOfCareHomeId = item.TypeOfCareHomeId,
                 TypeOfCareHomeName = item.TypeOfCareHomeName
             }).ToList();
        }

        public static IList<TypeOfNursingCareHomeResponse> ToResponse(IList<TypeOfNursingCareHomeDomain> typeOfNursingCareHomeDomain)
        {
            return typeOfNursingCareHomeDomain.Select(item
             => new TypeOfNursingCareHomeResponse
             {
                 TypeOfCareHomeId = item.TypeOfCareHomeId,
                 TypeOfCareHomeName = item.TypeOfCareHomeName
             }).ToList();
        }

        public static IList<NursingCareTypeOfStayOptionDomain> ToDomain(IList<NursingCareTypeOfStayOption> nursingCareTypeOfStayOptions)
        {
            return nursingCareTypeOfStayOptions.Select(item
             => new NursingCareTypeOfStayOptionDomain
             {
                 TypeOfStayOptionId = item.TypeOfStayOptionId,
                 OptionName = item.OptionName,
                 OptionPeriod = item.OptionPeriod
             }).ToList();
        }

        public static IList<NursingCareTypeOfStayOptionResponse> ToResponse(IList<NursingCareTypeOfStayOptionDomain> nursingCareTypeOfStayOptionDomains)
        {
            return nursingCareTypeOfStayOptionDomains.Select(item
             => new NursingCareTypeOfStayOptionResponse
             {
                 TypeOfStayOptionId = item.TypeOfStayOptionId,
                 OptionName = item.OptionName,
                 OptionPeriod = item.OptionPeriod
             }).ToList();
        }
    }
}
