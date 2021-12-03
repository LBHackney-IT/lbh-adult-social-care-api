using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Interfaces;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class GeneratedMappingProfile : Profile
    {
        public GeneratedMappingProfile()
        {
            CreateMap<CarePackageApprovableListItemDomain, CarePackage>().ReverseMap();
            CreateMap<CarePackageApprovableListItemDomain, CarePackageApprovableListItemResponse>().ReverseMap();
            CreateMap<CarePackageBrokerageDomain, CarePackageBrokerageResponse>().ReverseMap();
            CreateMap<CarePackageDetailDomain, CarePackageDetail>().ReverseMap();
            CreateMap<CarePackageDetailDomain, CarePackageDetailResponse>().ReverseMap();
            CreateMap<CarePackageDomain, CarePackage>().ReverseMap();
            CreateMap<CarePackageDomain, CarePackageResponse>().ReverseMap();
            CreateMap<CarePackageForCreationDomain, CarePackage>().ReverseMap();
            CreateMap<CarePackageForCreationDomain, CarePackageSettings>().ReverseMap();
            CreateMap<CarePackageHistoryDomain, CarePackageHistoryResponse>().ReverseMap();
            CreateMap<CarePackageListItemDomain, CarePackageListItemResponse>().ReverseMap();
            CreateMap<CarePackagePlainDomain, CarePackage>().ReverseMap();
            CreateMap<CarePackagePlainDomain, CarePackagePlainResponse>().ReverseMap();
            CreateMap<CarePackageReclaimCreationDomain, CarePackageReclaim>().ReverseMap();
            CreateMap<CarePackageReclaimDomain, CarePackageReclaim>().ReverseMap();
            CreateMap<CarePackageReclaimDomain, CarePackageReclaimResponse>().ReverseMap();
            CreateMap<CarePackageReclaimUpdateDomain, CarePackageReclaim>().ReverseMap();
            CreateMap<CarePackageResourceDomain, CarePackageResource>().ReverseMap();
            CreateMap<CarePackageResourceDomain, CarePackageResourceResponse>().ReverseMap();
            CreateMap<CarePackageSettingsDomain, CarePackageSettings>().ReverseMap();
            CreateMap<CarePackageSettingsDomain, CarePackageSettingsResponse>().ReverseMap();
            CreateMap<CarePackageSummaryDomain, CarePackageSummaryResponse>().ReverseMap();
            CreateMap<CarePackageSummaryReclaimsDomain, CarePackageSummaryReclaimsResponse>().ReverseMap();
            CreateMap<CarePackageUpdateDomain, CarePackage>().ReverseMap();
            CreateMap<CarePackageUpdateDomain, CarePackageSettings>().ReverseMap();
            CreateMap<BrokerPackageItemDomain, BrokerPackageItemResponse>().ReverseMap();
            CreateMap<BrokerPackageViewDomain, BrokerPackageViewResponse>().ReverseMap();
            CreateMap<ServiceUserBasicDomain, ServiceUser>().ReverseMap();
            CreateMap<ServiceUserBasicDomain, ServiceUserBasicResponse>().ReverseMap();
            CreateMap<ServiceUserDomain, ServiceUserResponse>().ReverseMap();
            CreateMap<DepartmentFlatDomain, Department>().ReverseMap();
            CreateMap<DepartmentFlatDomain, DepartmentFlatResponse>().ReverseMap();
            CreateMap<HeldInvoiceCreationDomain, HeldInvoice>().ReverseMap();
            CreateMap<HeldInvoiceDetailsDomain, HeldInvoiceDetailsResponse>().ReverseMap();
            CreateMap<HeldInvoiceFlatDomain, HeldInvoice>().ReverseMap();
            CreateMap<HeldInvoiceFlatDomain, HeldInvoiceFlatResponse>().ReverseMap();
            CreateMap<PayRunInvoiceItemDomain, PayRunInvoiceItemResponse>().ReverseMap();
            CreateMap<PayRunListDomain, PayRunListResponse>().ReverseMap();
            CreateMap<AppUserDomain, AppUserResponse>().ReverseMap();
            CreateMap<UsersMinimalDomain, User>().ReverseMap();
            CreateMap<CareChargeReclaimFileRequest, CareChargeReclaimFileDomain>().ReverseMap();
            CreateMap<CareChargeReclaimUpdateRequest, CarePackageReclaimUpdateDomain>().ReverseMap();
            CreateMap<CareChargesCreationRequest, CareChargesCreateDomain>().ReverseMap();
            CreateMap<CarePackageBrokerageCreationRequest, CarePackageBrokerageDomain>().ReverseMap();
            CreateMap<CarePackageDetailRequest, CarePackageDetailDomain>().ReverseMap();
            CreateMap<CarePackageDetailRequest, CarePackageDetail>().ReverseMap();
            CreateMap<CarePackageSubmissionRequest, CarePackageSubmissionDomain>().ReverseMap();
            CreateMap<CarePackageUpdateRequest, CarePackageUpdateDomain>().ReverseMap();
            CreateMap<CarePlanAssignmentRequest, CarePlanAssignmentDomain>().ReverseMap();
            CreateMap<CarePackageDetailResponse, CarePackageDetail>().ReverseMap();
            CreateMap<DraftPayRunCreationRequest, DraftPayRunCreationDomain>().ReverseMap();
            CreateMap<HeldInvoiceCreationRequest, HeldInvoiceCreationDomain>().ReverseMap();
        }
    }
}
