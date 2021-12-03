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

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static partial class MappingExtensions
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static IEnumerable<CarePackage> ToEntity(this IEnumerable<CarePackageApprovableListItemDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackage>>(input);
        }

        public static IEnumerable<CarePackageApprovableListItemDomain> ToApprovableListItemDomain(this IEnumerable<CarePackage> input)
        {
            return _mapper.Map<IEnumerable<CarePackageApprovableListItemDomain>>(input);
        }

        public static IEnumerable<CarePackageApprovableListItemResponse> ToResponse(this IEnumerable<CarePackageApprovableListItemDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageApprovableListItemResponse>>(input);
        }

        public static IEnumerable<CarePackageApprovableListItemDomain> ToDomain(this IEnumerable<CarePackageApprovableListItemResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackageApprovableListItemDomain>>(input);
        }

        public static CarePackageBrokerageResponse ToResponse(this CarePackageBrokerageDomain input)
        {
            return _mapper.Map<CarePackageBrokerageResponse>(input);
        }

        public static CarePackageBrokerageDomain ToDomain(this CarePackageBrokerageResponse input)
        {
            return _mapper.Map<CarePackageBrokerageDomain>(input);
        }

        public static CarePackageDetail ToEntity(this CarePackageDetailDomain input)
        {
            return _mapper.Map<CarePackageDetail>(input);
        }

        public static CarePackageDetailDomain ToDomain(this CarePackageDetail input)
        {
            return _mapper.Map<CarePackageDetailDomain>(input);
        }

        public static CarePackageDetailResponse ToResponse(this CarePackageDetailDomain input)
        {
            return _mapper.Map<CarePackageDetailResponse>(input);
        }

        public static CarePackageDetailDomain ToDomain(this CarePackageDetailResponse input)
        {
            return _mapper.Map<CarePackageDetailDomain>(input);
        }

        public static IEnumerable<CarePackageDetail> ToEntity(this IEnumerable<CarePackageDetailDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageDetail>>(input);
        }

        public static IEnumerable<CarePackageDetailDomain> ToDomain(this IEnumerable<CarePackageDetail> input)
        {
            return _mapper.Map<IEnumerable<CarePackageDetailDomain>>(input);
        }

        public static CarePackage ToEntity(this CarePackageDomain input)
        {
            return _mapper.Map<CarePackage>(input);
        }

        public static CarePackageDomain ToDomain(this CarePackage input)
        {
            return _mapper.Map<CarePackageDomain>(input);
        }

        public static CarePackageResponse ToResponse(this CarePackageDomain input)
        {
            return _mapper.Map<CarePackageResponse>(input);
        }

        public static CarePackageDomain ToDomain(this CarePackageResponse input)
        {
            return _mapper.Map<CarePackageDomain>(input);
        }

        public static CarePackage ToEntity(this CarePackageForCreationDomain input)
        {
            return _mapper.Map<CarePackage>(input);
        }

        public static CarePackageForCreationDomain ToForCreationDomain(this CarePackage input)
        {
            return _mapper.Map<CarePackageForCreationDomain>(input);
        }

        public static CarePackageSettings ToSettings(this CarePackageForCreationDomain input)
        {
            return _mapper.Map<CarePackageSettings>(input);
        }

        public static CarePackageForCreationDomain ToForCreationDomain(this CarePackageSettings input)
        {
            return _mapper.Map<CarePackageForCreationDomain>(input);
        }

        public static CarePackageHistoryResponse ToResponse(this CarePackageHistoryDomain input)
        {
            return _mapper.Map<CarePackageHistoryResponse>(input);
        }

        public static CarePackageHistoryDomain ToDomain(this CarePackageHistoryResponse input)
        {
            return _mapper.Map<CarePackageHistoryDomain>(input);
        }

        public static IEnumerable<CarePackageHistoryResponse> ToResponse(this IEnumerable<CarePackageHistoryDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageHistoryResponse>>(input);
        }

        public static IEnumerable<CarePackageHistoryDomain> ToDomain(this IEnumerable<CarePackageHistoryResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackageHistoryDomain>>(input);
        }

        public static CarePackageListItemResponse ToResponse(this CarePackageListItemDomain input)
        {
            return _mapper.Map<CarePackageListItemResponse>(input);
        }

        public static CarePackageListItemDomain ToDomain(this CarePackageListItemResponse input)
        {
            return _mapper.Map<CarePackageListItemDomain>(input);
        }

        public static IEnumerable<CarePackageListItemResponse> ToResponse(this IEnumerable<CarePackageListItemDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageListItemResponse>>(input);
        }

        public static IEnumerable<CarePackageListItemDomain> ToDomain(this IEnumerable<CarePackageListItemResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackageListItemDomain>>(input);
        }

        public static CarePackage ToEntity(this CarePackagePlainDomain input)
        {
            return _mapper.Map<CarePackage>(input);
        }

        public static CarePackagePlainDomain ToPlainDomain(this CarePackage input)
        {
            return _mapper.Map<CarePackagePlainDomain>(input);
        }

        public static CarePackagePlainResponse ToResponse(this CarePackagePlainDomain input)
        {
            return _mapper.Map<CarePackagePlainResponse>(input);
        }

        public static CarePackagePlainDomain ToDomain(this CarePackagePlainResponse input)
        {
            return _mapper.Map<CarePackagePlainDomain>(input);
        }

        public static IEnumerable<CarePackage> ToEntity(this IEnumerable<CarePackagePlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackage>>(input);
        }

        public static IEnumerable<CarePackagePlainDomain> ToPlainDomain(this IEnumerable<CarePackage> input)
        {
            return _mapper.Map<IEnumerable<CarePackagePlainDomain>>(input);
        }

        public static IEnumerable<CarePackagePlainResponse> ToResponse(this IEnumerable<CarePackagePlainDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackagePlainResponse>>(input);
        }

        public static IEnumerable<CarePackagePlainDomain> ToDomain(this IEnumerable<CarePackagePlainResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackagePlainDomain>>(input);
        }

        public static CarePackageReclaim ToEntity(this CarePackageReclaimCreationDomain input)
        {
            return _mapper.Map<CarePackageReclaim>(input);
        }

        public static CarePackageReclaimCreationDomain ToCreationDomain(this CarePackageReclaim input)
        {
            return _mapper.Map<CarePackageReclaimCreationDomain>(input);
        }

        public static CarePackageReclaim ToEntity(this CarePackageReclaimDomain input)
        {
            return _mapper.Map<CarePackageReclaim>(input);
        }

        public static CarePackageReclaimDomain ToDomain(this CarePackageReclaim input)
        {
            return _mapper.Map<CarePackageReclaimDomain>(input);
        }

        public static CarePackageReclaimResponse ToResponse(this CarePackageReclaimDomain input)
        {
            return _mapper.Map<CarePackageReclaimResponse>(input);
        }

        public static CarePackageReclaimDomain ToDomain(this CarePackageReclaimResponse input)
        {
            return _mapper.Map<CarePackageReclaimDomain>(input);
        }

        public static IEnumerable<CarePackageReclaim> ToEntity(this IEnumerable<CarePackageReclaimDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageReclaim>>(input);
        }

        public static IEnumerable<CarePackageReclaimDomain> ToDomain(this IEnumerable<CarePackageReclaim> input)
        {
            return _mapper.Map<IEnumerable<CarePackageReclaimDomain>>(input);
        }

        public static IEnumerable<CarePackageReclaimResponse> ToResponse(this IEnumerable<CarePackageReclaimDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageReclaimResponse>>(input);
        }

        public static IEnumerable<CarePackageReclaimDomain> ToDomain(this IEnumerable<CarePackageReclaimResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackageReclaimDomain>>(input);
        }

        public static CarePackageReclaim ToEntity(this CarePackageReclaimUpdateDomain input)
        {
            return _mapper.Map<CarePackageReclaim>(input);
        }

        public static CarePackageReclaimUpdateDomain ToUpdateDomain(this CarePackageReclaim input)
        {
            return _mapper.Map<CarePackageReclaimUpdateDomain>(input);
        }

        public static IEnumerable<CarePackageReclaim> ToEntity(this IEnumerable<CarePackageReclaimUpdateDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageReclaim>>(input);
        }

        public static IEnumerable<CarePackageReclaimUpdateDomain> ToUpdateDomain(this IEnumerable<CarePackageReclaim> input)
        {
            return _mapper.Map<IEnumerable<CarePackageReclaimUpdateDomain>>(input);
        }

        public static CarePackageResource ToEntity(this CarePackageResourceDomain input)
        {
            return _mapper.Map<CarePackageResource>(input);
        }

        public static CarePackageResourceDomain ToDomain(this CarePackageResource input)
        {
            return _mapper.Map<CarePackageResourceDomain>(input);
        }

        public static IEnumerable<CarePackageResource> ToEntity(this IEnumerable<CarePackageResourceDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageResource>>(input);
        }

        public static IEnumerable<CarePackageResourceDomain> ToDomain(this IEnumerable<CarePackageResource> input)
        {
            return _mapper.Map<IEnumerable<CarePackageResourceDomain>>(input);
        }

        public static CarePackageResourceResponse ToResponse(this CarePackageResourceDomain input)
        {
            return _mapper.Map<CarePackageResourceResponse>(input);
        }

        public static CarePackageResourceDomain ToDomain(this CarePackageResourceResponse input)
        {
            return _mapper.Map<CarePackageResourceDomain>(input);
        }

        public static IEnumerable<CarePackageResourceResponse> ToResponse(this IEnumerable<CarePackageResourceDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageResourceResponse>>(input);
        }

        public static IEnumerable<CarePackageResourceDomain> ToDomain(this IEnumerable<CarePackageResourceResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackageResourceDomain>>(input);
        }

        public static CarePackageSettings ToEntity(this CarePackageSettingsDomain input)
        {
            return _mapper.Map<CarePackageSettings>(input);
        }

        public static CarePackageSettingsDomain ToDomain(this CarePackageSettings input)
        {
            return _mapper.Map<CarePackageSettingsDomain>(input);
        }

        public static CarePackageSettingsResponse ToResponse(this CarePackageSettingsDomain input)
        {
            return _mapper.Map<CarePackageSettingsResponse>(input);
        }

        public static CarePackageSettingsDomain ToDomain(this CarePackageSettingsResponse input)
        {
            return _mapper.Map<CarePackageSettingsDomain>(input);
        }

        public static IEnumerable<CarePackageSettingsResponse> ToResponse(this IEnumerable<CarePackageSettingsDomain> input)
        {
            return _mapper.Map<IEnumerable<CarePackageSettingsResponse>>(input);
        }

        public static IEnumerable<CarePackageSettingsDomain> ToDomain(this IEnumerable<CarePackageSettingsResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackageSettingsDomain>>(input);
        }

        public static CarePackageSummaryResponse ToResponse(this CarePackageSummaryDomain input)
        {
            return _mapper.Map<CarePackageSummaryResponse>(input);
        }

        public static CarePackageSummaryDomain ToDomain(this CarePackageSummaryResponse input)
        {
            return _mapper.Map<CarePackageSummaryDomain>(input);
        }

        public static CarePackageSummaryReclaimsResponse ToResponse(this CarePackageSummaryReclaimsDomain input)
        {
            return _mapper.Map<CarePackageSummaryReclaimsResponse>(input);
        }

        public static CarePackageSummaryReclaimsDomain ToDomain(this CarePackageSummaryReclaimsResponse input)
        {
            return _mapper.Map<CarePackageSummaryReclaimsDomain>(input);
        }

        public static CarePackage ToEntity(this CarePackageUpdateDomain input)
        {
            return _mapper.Map<CarePackage>(input);
        }

        public static CarePackageUpdateDomain ToUpdateDomain(this CarePackage input)
        {
            return _mapper.Map<CarePackageUpdateDomain>(input);
        }

        public static CarePackageSettings ToSettings(this CarePackageUpdateDomain input)
        {
            return _mapper.Map<CarePackageSettings>(input);
        }

        public static CarePackageUpdateDomain ToUpdateDomain(this CarePackageSettings input)
        {
            return _mapper.Map<CarePackageUpdateDomain>(input);
        }

        public static BrokerPackageItemResponse ToResponse(this BrokerPackageItemDomain input)
        {
            return _mapper.Map<BrokerPackageItemResponse>(input);
        }

        public static BrokerPackageItemDomain ToDomain(this BrokerPackageItemResponse input)
        {
            return _mapper.Map<BrokerPackageItemDomain>(input);
        }

        public static IEnumerable<BrokerPackageItemResponse> ToResponse(this IEnumerable<BrokerPackageItemDomain> input)
        {
            return _mapper.Map<IEnumerable<BrokerPackageItemResponse>>(input);
        }

        public static IEnumerable<BrokerPackageItemDomain> ToDomain(this IEnumerable<BrokerPackageItemResponse> input)
        {
            return _mapper.Map<IEnumerable<BrokerPackageItemDomain>>(input);
        }

        public static BrokerPackageViewResponse ToResponse(this BrokerPackageViewDomain input)
        {
            return _mapper.Map<BrokerPackageViewResponse>(input);
        }

        public static BrokerPackageViewDomain ToDomain(this BrokerPackageViewResponse input)
        {
            return _mapper.Map<BrokerPackageViewDomain>(input);
        }

        public static ServiceUser ToEntity(this ServiceUserBasicDomain input)
        {
            return _mapper.Map<ServiceUser>(input);
        }

        public static ServiceUserBasicDomain ToBasicDomain(this ServiceUser input)
        {
            return _mapper.Map<ServiceUserBasicDomain>(input);
        }

        public static ServiceUserBasicResponse ToResponse(this ServiceUserBasicDomain input)
        {
            return _mapper.Map<ServiceUserBasicResponse>(input);
        }

        public static ServiceUserBasicDomain ToDomain(this ServiceUserBasicResponse input)
        {
            return _mapper.Map<ServiceUserBasicDomain>(input);
        }

        public static ServiceUserResponse ToResponse(this ServiceUserDomain input)
        {
            return _mapper.Map<ServiceUserResponse>(input);
        }

        public static ServiceUserDomain ToDomain(this ServiceUserResponse input)
        {
            return _mapper.Map<ServiceUserDomain>(input);
        }

        public static Department ToEntity(this DepartmentFlatDomain input)
        {
            return _mapper.Map<Department>(input);
        }

        public static DepartmentFlatDomain ToFlatDomain(this Department input)
        {
            return _mapper.Map<DepartmentFlatDomain>(input);
        }

        public static DepartmentFlatResponse ToResponse(this DepartmentFlatDomain input)
        {
            return _mapper.Map<DepartmentFlatResponse>(input);
        }

        public static DepartmentFlatDomain ToDomain(this DepartmentFlatResponse input)
        {
            return _mapper.Map<DepartmentFlatDomain>(input);
        }

        public static IEnumerable<Department> ToEntity(this IEnumerable<DepartmentFlatDomain> input)
        {
            return _mapper.Map<IEnumerable<Department>>(input);
        }

        public static IEnumerable<DepartmentFlatDomain> ToFlatDomain(this IEnumerable<Department> input)
        {
            return _mapper.Map<IEnumerable<DepartmentFlatDomain>>(input);
        }

        public static IEnumerable<DepartmentFlatResponse> ToResponse(this IEnumerable<DepartmentFlatDomain> input)
        {
            return _mapper.Map<IEnumerable<DepartmentFlatResponse>>(input);
        }

        public static IEnumerable<DepartmentFlatDomain> ToDomain(this IEnumerable<DepartmentFlatResponse> input)
        {
            return _mapper.Map<IEnumerable<DepartmentFlatDomain>>(input);
        }

        public static HeldInvoice ToEntity(this HeldInvoiceCreationDomain input)
        {
            return _mapper.Map<HeldInvoice>(input);
        }

        public static HeldInvoiceCreationDomain ToCreationDomain(this HeldInvoice input)
        {
            return _mapper.Map<HeldInvoiceCreationDomain>(input);
        }

        public static IEnumerable<HeldInvoiceDetailsResponse> ToResponse(this IEnumerable<HeldInvoiceDetailsDomain> input)
        {
            return _mapper.Map<IEnumerable<HeldInvoiceDetailsResponse>>(input);
        }

        public static IEnumerable<HeldInvoiceDetailsDomain> ToDomain(this IEnumerable<HeldInvoiceDetailsResponse> input)
        {
            return _mapper.Map<IEnumerable<HeldInvoiceDetailsDomain>>(input);
        }

        public static HeldInvoice ToEntity(this HeldInvoiceFlatDomain input)
        {
            return _mapper.Map<HeldInvoice>(input);
        }

        public static HeldInvoiceFlatDomain ToFlatDomain(this HeldInvoice input)
        {
            return _mapper.Map<HeldInvoiceFlatDomain>(input);
        }

        public static HeldInvoiceFlatResponse ToResponse(this HeldInvoiceFlatDomain input)
        {
            return _mapper.Map<HeldInvoiceFlatResponse>(input);
        }

        public static HeldInvoiceFlatDomain ToDomain(this HeldInvoiceFlatResponse input)
        {
            return _mapper.Map<HeldInvoiceFlatDomain>(input);
        }

        public static IEnumerable<PayRunInvoiceItemResponse> ToResponse(this IEnumerable<PayRunInvoiceItemDomain> input)
        {
            return _mapper.Map<IEnumerable<PayRunInvoiceItemResponse>>(input);
        }

        public static IEnumerable<PayRunInvoiceItemDomain> ToDomain(this IEnumerable<PayRunInvoiceItemResponse> input)
        {
            return _mapper.Map<IEnumerable<PayRunInvoiceItemDomain>>(input);
        }

        public static IEnumerable<PayRunListResponse> ToResponse(this IEnumerable<PayRunListDomain> input)
        {
            return _mapper.Map<IEnumerable<PayRunListResponse>>(input);
        }

        public static IEnumerable<PayRunListDomain> ToDomain(this IEnumerable<PayRunListResponse> input)
        {
            return _mapper.Map<IEnumerable<PayRunListDomain>>(input);
        }

        public static AppUserResponse ToResponse(this AppUserDomain input)
        {
            return _mapper.Map<AppUserResponse>(input);
        }

        public static AppUserDomain ToDomain(this AppUserResponse input)
        {
            return _mapper.Map<AppUserDomain>(input);
        }

        public static IEnumerable<AppUserResponse> ToResponse(this IEnumerable<AppUserDomain> input)
        {
            return _mapper.Map<IEnumerable<AppUserResponse>>(input);
        }

        public static IEnumerable<AppUserDomain> ToDomain(this IEnumerable<AppUserResponse> input)
        {
            return _mapper.Map<IEnumerable<AppUserDomain>>(input);
        }

        public static User ToEntity(this UsersMinimalDomain input)
        {
            return _mapper.Map<User>(input);
        }

        public static UsersMinimalDomain TosMinimalDomain(this User input)
        {
            return _mapper.Map<UsersMinimalDomain>(input);
        }

        public static CareChargeReclaimFileDomain ToDomain(this CareChargeReclaimFileRequest input)
        {
            return _mapper.Map<CareChargeReclaimFileDomain>(input);
        }

        public static CareChargeReclaimFileRequest ToRequest(this CareChargeReclaimFileDomain input)
        {
            return _mapper.Map<CareChargeReclaimFileRequest>(input);
        }

        public static IEnumerable<CarePackageReclaimUpdateDomain> ToDomain(this IEnumerable<CareChargeReclaimUpdateRequest> input)
        {
            return _mapper.Map<IEnumerable<CarePackageReclaimUpdateDomain>>(input);
        }

        public static IEnumerable<CareChargeReclaimUpdateRequest> ToRequest(this IEnumerable<CarePackageReclaimUpdateDomain> input)
        {
            return _mapper.Map<IEnumerable<CareChargeReclaimUpdateRequest>>(input);
        }

        public static CareChargesCreateDomain ToeDomain(this CareChargesCreationRequest input)
        {
            return _mapper.Map<CareChargesCreateDomain>(input);
        }

        public static CareChargesCreationRequest ToionRequest(this CareChargesCreateDomain input)
        {
            return _mapper.Map<CareChargesCreationRequest>(input);
        }

        public static CarePackageBrokerageDomain ToDomain(this CarePackageBrokerageCreationRequest input)
        {
            return _mapper.Map<CarePackageBrokerageDomain>(input);
        }

        public static CarePackageBrokerageCreationRequest ToCreationRequest(this CarePackageBrokerageDomain input)
        {
            return _mapper.Map<CarePackageBrokerageCreationRequest>(input);
        }

        public static CarePackageDetailDomain ToDomain(this CarePackageDetailRequest input)
        {
            return _mapper.Map<CarePackageDetailDomain>(input);
        }

        public static CarePackageDetailRequest ToRequest(this CarePackageDetailDomain input)
        {
            return _mapper.Map<CarePackageDetailRequest>(input);
        }

        public static IEnumerable<CarePackageDetail> ToEntity(this IEnumerable<CarePackageDetailRequest> input)
        {
            return _mapper.Map<IEnumerable<CarePackageDetail>>(input);
        }

        public static IEnumerable<CarePackageDetailRequest> ToRequest(this IEnumerable<CarePackageDetail> input)
        {
            return _mapper.Map<IEnumerable<CarePackageDetailRequest>>(input);
        }

        public static CarePackageSubmissionDomain ToDomain(this CarePackageSubmissionRequest input)
        {
            return _mapper.Map<CarePackageSubmissionDomain>(input);
        }

        public static CarePackageSubmissionRequest ToRequest(this CarePackageSubmissionDomain input)
        {
            return _mapper.Map<CarePackageSubmissionRequest>(input);
        }

        public static CarePackageUpdateDomain ToDomain(this CarePackageUpdateRequest input)
        {
            return _mapper.Map<CarePackageUpdateDomain>(input);
        }

        public static CarePackageUpdateRequest ToRequest(this CarePackageUpdateDomain input)
        {
            return _mapper.Map<CarePackageUpdateRequest>(input);
        }

        public static CarePlanAssignmentDomain ToDomain(this CarePlanAssignmentRequest input)
        {
            return _mapper.Map<CarePlanAssignmentDomain>(input);
        }

        public static CarePlanAssignmentRequest ToRequest(this CarePlanAssignmentDomain input)
        {
            return _mapper.Map<CarePlanAssignmentRequest>(input);
        }

        public static IEnumerable<CarePackageDetail> ToEntity(this IEnumerable<CarePackageDetailResponse> input)
        {
            return _mapper.Map<IEnumerable<CarePackageDetail>>(input);
        }

        public static IEnumerable<CarePackageDetailResponse> ToResponse(this IEnumerable<CarePackageDetail> input)
        {
            return _mapper.Map<IEnumerable<CarePackageDetailResponse>>(input);
        }

        public static DraftPayRunCreationDomain ToDomain(this DraftPayRunCreationRequest input)
        {
            return _mapper.Map<DraftPayRunCreationDomain>(input);
        }

        public static DraftPayRunCreationRequest ToRequest(this DraftPayRunCreationDomain input)
        {
            return _mapper.Map<DraftPayRunCreationRequest>(input);
        }

        public static HeldInvoiceCreationDomain ToDomain(this HeldInvoiceCreationRequest input)
        {
            return _mapper.Map<HeldInvoiceCreationDomain>(input);
        }

        public static HeldInvoiceCreationRequest ToRequest(this HeldInvoiceCreationDomain input)
        {
            return _mapper.Map<HeldInvoiceCreationRequest>(input);
        }
    }
}
