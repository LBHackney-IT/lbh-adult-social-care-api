using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class GeneratedMappingProfile : Profile
    {
        public GeneratedMappingProfile()
        {
            CreateMap<BrokerPackageItemDomain, BrokerPackageItemResponse>().ReverseMap();
            CreateMap<BrokerPackageViewDomain, BrokerPackageViewResponse>().ReverseMap();
            CreateMap<CareChargeElementPlainDomain, CareChargeElementCreationResponse>().ReverseMap();
            CreateMap<CareChargeElementTypePlainDomain, CareChargeElementTypePlainResponse>().ReverseMap();
            CreateMap<CarePackageBrokerageDomain, CarePackageBrokerageResponse>().ReverseMap();
            CreateMap<CarePackageCoreDomain, CarePackageCoreResponse>().ReverseMap();
            CreateMap<CarePackageDetailDomain, CarePackageDetail>().ReverseMap();
            CreateMap<CarePackageDetailDomain, CarePackageDetailResponse>().ReverseMap();
            CreateMap<CarePackageDomain, CarePackageResponse>().ReverseMap();
            CreateMap<CarePackageListItemDomain, CarePackageListItemResponse>().ReverseMap();
            CreateMap<CarePackagePlainDomain, CarePackagePlainResponse>().ReverseMap();
            CreateMap<CarePackageReclaimCreationDomain, CarePackageReclaim>().ReverseMap();
            CreateMap<CarePackageReclaimDomain, CarePackageReclaimResponse>().ReverseMap();
            CreateMap<CarePackageSettingsDomain, CarePackageSettingsResponse>().ReverseMap();
            CreateMap<CarePackageSummaryDomain, CarePackageSummaryResponse>().ReverseMap();
            CreateMap<CarePackageSummaryReclaimsDomain, CarePackageSummaryReclaimsResponse>().ReverseMap();
            CreateMap<CarePackageUpdateDomain, CarePackageSettings>().ReverseMap();
            CreateMap<CarePackageUpdateDomain, CarePackage>().ReverseMap();
            CreateMap<ClientsDomain, ClientsResponse>().ReverseMap();
            CreateMap<ServiceUserBasicDomain, ServiceUserBasicResponse>().ReverseMap();
            CreateMap<CarePackageForCreationDomain, CarePackage>().ReverseMap();
            CreateMap<CarePackageForCreationDomain, CarePackageSettings>().ReverseMap();
            CreateMap<AppUserDomain, AppUserResponse>().ReverseMap();
            CreateMap<Client, ServiceUserBasicDomain>().ReverseMap();
            CreateMap<CareChargeElementCreationRequest, CareChargeElementPlainDomain>().ReverseMap();
            CreateMap<CareChargeElementForUpdateRequest, CareChargeElementForUpdateDomain>().ReverseMap();
            CreateMap<CarePackageBrokerageCreationRequest, CarePackageBrokerageDomain>().ReverseMap();
            CreateMap<CarePackageDetailRequest, CarePackageDetailDomain>().ReverseMap();
            CreateMap<CarePackageSubmissionRequest, CarePackageSubmissionDomain>().ReverseMap();
            CreateMap<CarePackageUpdateRequest, CarePackageUpdateDomain>().ReverseMap();
            CreateMap<EndCareChargeElementRequest, EndCareChargeElementDomain>().ReverseMap();
            CreateMap<CareChargeElement, CareChargeElementPlainDomain>().ReverseMap();
            CreateMap<CareChargeType, CareChargeElementTypePlainDomain>().ReverseMap();
            CreateMap<PackageCareCharge, PackageCareChargeDomain>().ReverseMap();
            CreateMap<CarePackage, CarePackageDomain>().ReverseMap();
            CreateMap<CarePackage, CarePackagePlainDomain>().ReverseMap();
            CreateMap<CarePackageDetail, CarePackageDetailRequest>().ReverseMap();
            CreateMap<CarePackageDetail, CarePackageDetailResponse>().ReverseMap();
            CreateMap<CarePackageReclaim, CarePackageReclaimDomain>().ReverseMap();
            CreateMap<CarePackageSettings, CarePackageSettingsDomain>().ReverseMap();
        }
    }
}
