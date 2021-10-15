using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class GeneratedMappingProfile : Profile
    {
        public GeneratedMappingProfile()
        {
            CreateMap<CarePackageBrokerageDomain, CarePackageBrokerageResponse>().ReverseMap();
            CreateMap<CarePackageCoreDomain, CarePackageCoreResponse>().ReverseMap();
            CreateMap<CarePackageDetailDomain, CarePackageDetail>().ReverseMap();
            CreateMap<CarePackageDetailDomain, CarePackageDetailResponse>().ReverseMap();
            CreateMap<CarePackageDomain, CarePackageResponse>().ReverseMap();
            CreateMap<CarePackageForCreationDomain, CarePackage>().ReverseMap();
            CreateMap<CarePackageForCreationDomain, CarePackageSettings>().ReverseMap();
            CreateMap<CarePackageHistoryDomain, CarePackageHistoryResponse>().ReverseMap();
            CreateMap<CarePackageListItemDomain, CarePackageListItemResponse>().ReverseMap();
            CreateMap<CarePackagePlainDomain, CarePackagePlainResponse>().ReverseMap();
            CreateMap<CarePackageReclaimCreationDomain, CarePackageReclaim>().ReverseMap();
            CreateMap<CarePackageReclaimDomain, CarePackageReclaimResponse>().ReverseMap();
            CreateMap<CarePackageSettingsDomain, CarePackageSettingsResponse>().ReverseMap();
            CreateMap<CarePackageSummaryDomain, CarePackageSummaryResponse>().ReverseMap();
            CreateMap<CarePackageSummaryReclaimsDomain, CarePackageSummaryReclaimsResponse>().ReverseMap();
            CreateMap<CarePackageUpdateDomain, CarePackageSettings>().ReverseMap();
            CreateMap<CarePackageUpdateDomain, CarePackage>().ReverseMap();
            CreateMap<BrokerPackageItemDomain, BrokerPackageItemResponse>().ReverseMap();
            CreateMap<BrokerPackageViewDomain, BrokerPackageViewResponse>().ReverseMap();
            CreateMap<ServiceUserBasicDomain, ServiceUserBasicResponse>().ReverseMap();
            CreateMap<ServiceUserDomain, ServiceUserResponse>().ReverseMap();
            CreateMap<AppUserDomain, AppUserResponse>().ReverseMap();
            CreateMap<CarePackageBrokerageCreationRequest, CarePackageBrokerageDomain>().ReverseMap();
            CreateMap<CarePackageDetailRequest, CarePackageDetailDomain>().ReverseMap();
            CreateMap<CarePackageSubmissionRequest, CarePackageSubmissionDomain>().ReverseMap();
            CreateMap<CarePackageUpdateRequest, CarePackageUpdateDomain>().ReverseMap();
            CreateMap<CarePackage, CarePackageDomain>().ReverseMap();
            CreateMap<CarePackage, CarePackagePlainDomain>().ReverseMap();
            CreateMap<CarePackageDetail, CarePackageDetailRequest>().ReverseMap();
            CreateMap<CarePackageDetail, CarePackageDetailResponse>().ReverseMap();
            CreateMap<CarePackageReclaim, CarePackageReclaimDomain>().ReverseMap();
            CreateMap<CarePackageSettings, CarePackageSettingsDomain>().ReverseMap();
            CreateMap<ServiceUser, ServiceUserBasicDomain>().ReverseMap();
        }
    }
}
