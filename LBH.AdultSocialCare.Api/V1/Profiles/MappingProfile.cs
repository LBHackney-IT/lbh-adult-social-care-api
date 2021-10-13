using AutoMapper;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCarePackageReclaims;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region TermTimeConsiderationOptions

            CreateMap<TermTimeConsiderationOption, TermTimeConsiderationOptionDomain>();
            CreateMap<TermTimeConsiderationOptionDomain, TermTimeConsiderationOptionResponse>();

            #endregion TermTimeConsiderationOptions

            #region OpportunityLengthOptions

            CreateMap<OpportunityLengthOption, OpportunityLengthOptionDomain>();
            CreateMap<OpportunityLengthOptionDomain, OpportunityLengthOptionResponse>();

            #endregion OpportunityLengthOptions

            #region OpportunityTimesPerMonthOptions

            CreateMap<OpportunityTimesPerMonthOption, OpportunityTimesPerMonthOptionDomain>();
            CreateMap<OpportunityTimesPerMonthOptionDomain, OpportunityTimesPerMonthOptionResponse>();

            #endregion OpportunityTimesPerMonthOptions

            #region ResidentialCarePackage

            CreateMap<TypeOfResidentialCareHome, TypeOfResidentialCareHomeDomain>();
            CreateMap<ResidentialCarePackageDomain, ResidentialCarePackageResponse>();
            CreateMap<ResidentialCarePackage, ResidentialCarePackageDomain>();
            CreateMap<ResidentialCarePackageDomain, ResidentialCarePackage>();
            CreateMap<ResidentialCarePackageDomain, ResidentialCarePackageForUpdateDomain>();
            CreateMap<ResidentialCareTypeOfStayOption, ResidentialCareTypeOfStayOptionDomain>();
            CreateMap<ResidentialCareTypeOfStayOptionDomain, ResidentialCareTypeOfStayOptionResponse>();
            CreateMap<ResidentialCarePackageForUpdateRequest, ResidentialCarePackageDomain>();
            CreateMap<CarePackageForCreationRequest, CarePackageForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedForCreationRequest, ResidentialCareAdditionalNeedForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCreationRequest, ResidentialCareAdditionalNeedForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedForCreationDomain, ResidentialCareAdditionalNeed>();
            CreateMap<ResidentialCareAdditionalNeed, ResidentialCareAdditionalNeedsDomain>();
            CreateMap<ResidentialCareAdditionalNeedsDomain, ResidentialCareAdditionalNeedsResponse>();
            CreateMap<CarePackageForCreationDomain, ResidentialCarePackage>();
            CreateMap<ResidentialCarePackageForUpdateDomain, ResidentialCarePackage>();
            CreateMap<TypeOfResidentialCareHomeDomain, TypeOfResidentialCareHomeResponse>();
            CreateMap<ResidentialCareApprovalHistory, ResidentialCareApprovalHistoryDomain>();
            CreateMap<ResidentialCareApprovalHistoryDomain, ResidentialCareApprovalHistory>();
            CreateMap<ResidentialCarePackage, ResidentialCarePackagePlainDomain>();
            CreateMap<ResidentialCarePackagePlainDomain, ResidentialCarePackageForUpdateDomain>();

            #endregion ResidentialCarePackage

            #region Supplier

            CreateMap<Supplier, SupplierDomain>();
            CreateMap<SupplierDomain, Supplier>();
            CreateMap<SupplierDomain, SupplierResponse>();
            CreateMap<SupplierResponse, SupplierDomain>();
            CreateMap<SupplierCreationDomain, SupplierCreationRequest>();
            CreateMap<SupplierCreationRequest, SupplierCreationDomain>();
            CreateMap<SupplierCreationDomain, Supplier>();
            CreateMap<Supplier, SupplierCreationDomain>();
            CreateMap<SupplierMinimalDomain, SupplierMinimalResponse>();

            #endregion Supplier

            #region ResidentialCareApprovePackage

            CreateMap<ResidentialCareApprovePackageDomain, ResidentialCareApprovePackageResponse>();
            CreateMap<ResidentialCareApprovePackageResponse, ResidentialCareApprovePackageDomain>();

            #endregion ResidentialCareApprovePackage

            #region ResidentialCareApproveBrokered

            CreateMap<ResidentialCareApproveBrokeredDomain, ResidentialCareApproveBrokeredResponse>();
            CreateMap<ResidentialCareApproveBrokeredResponse, ResidentialCareApproveBrokeredDomain>();

            #endregion ResidentialCareApproveBrokered

            #region ResidentialCareBrokerage

            CreateMap<ResidentialCareApprovalHistory, ResidentialCareApprovalHistoryDomain>();
            CreateMap<ResidentialCareApprovalHistoryDomain, ResidentialCareApprovalHistory>();
            CreateMap<ResidentialCareApprovalHistoryResponse, ResidentialCareApprovalHistoryDomain>();
            CreateMap<ResidentialCareApprovalHistoryDomain, ResidentialCareApprovalHistoryResponse>();
            CreateMap<ResidentialCareRequestMoreInformationForCreationRequest, ResidentialCareRequestMoreInformationDomain>();
            CreateMap<ResidentialCareRequestMoreInformationDomain, ResidentialCareRequestMoreInformationForCreationRequest>();
            CreateMap<ResidentialCareRequestMoreInformationDomain, ResidentialCareRequestMoreInformation>();
            CreateMap<ResidentialCareRequestMoreInformation, ResidentialCareRequestMoreInformationDomain>();
            CreateMap<ResidentialCareBrokerageInfo, ResidentialCareBrokerageInfoDomain>();
            CreateMap<ResidentialCareBrokerageInfoDomain, ResidentialCareBrokerageInfo>();
            CreateMap<ResidentialCareBrokerageInfoDomain, ResidentialCareBrokerageInfoResponse>();
            CreateMap<ResidentialCareBrokerageInfoResponse, ResidentialCareBrokerageInfoDomain>();
            CreateMap<ResidentialCareBrokerageForCreationDomain, ResidentialCareBrokerageForCreationRequest>();
            CreateMap<ResidentialCareBrokerageForCreationRequest, ResidentialCareBrokerageForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCostCreationDomain, ResidentialCareAdditionalNeedsCostCreationRequest>();
            CreateMap<ResidentialCareAdditionalNeedsCostCreationRequest, ResidentialCareAdditionalNeedsCostCreationDomain>();
            CreateMap<ResidentialCareBrokerageForCreationDomain, ResidentialCareBrokerageInfo>();
            CreateMap<ResidentialCareBrokerageInfo, ResidentialCareBrokerageForCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCostCreationDomain, ResidentialCareAdditionalNeedsCost>();
            CreateMap<ResidentialCareAdditionalNeedsCost, ResidentialCareAdditionalNeedsCostCreationDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCost, ResidentialCareAdditionalNeedsCostDomain>();
            CreateMap<ResidentialCareAdditionalNeedsCostDomain, ResidentialCareAdditionalNeedsCostResponse>();

            #endregion ResidentialCareBrokerage

            #region Stage

            CreateMap<Stage, StageDomain>();
            CreateMap<StageDomain, Stage>();

            #endregion Stage

            #region ServiceUsers

            CreateMap<User, AppUserDomain>();
            CreateMap<AppUserDomain, AppUserResponse>();
            CreateMap<UsersMinimalDomain, UsersMinimalResponse>();

            #endregion ServiceUsers

            #region PackageReclaim

            CreateMap<ReclaimAmountOption, ReclaimAmountOptionDomain>();
            CreateMap<ReclaimAmountOptionDomain, ReclaimAmountOptionResponse>();
            CreateMap<ReclaimCategory, ReclaimCategoryDomain>();
            CreateMap<ReclaimCategoryDomain, ReclaimCategoryResponse>();
            CreateMap<ReclaimFrom, ReclaimFromDomain>();
            CreateMap<ReclaimFromDomain, ReclaimFromResponse>();
            CreateMap<ResidentialCarePackageReclaim, ResidentialCarePackageClaimDomain>();
            CreateMap<ResidentialCarePackageClaimDomain, ResidentialCarePackageReclaim>();
            CreateMap<ResidentialCarePackageClaimDomain, ResidentialCarePackageClaimResponse>();
            CreateMap<ResidentialCarePackageClaimResponse, ResidentialCarePackageClaimDomain>();
            CreateMap<ResidentialCarePackageClaimCreationDomain, ResidentialCarePackageClaimCreationRequest>();
            CreateMap<ResidentialCarePackageClaimCreationRequest, ResidentialCarePackageClaimCreationDomain>();
            CreateMap<ResidentialCarePackageClaimCreationDomain, ResidentialCarePackageReclaim>();
            CreateMap<ResidentialCarePackageReclaim, ResidentialCarePackageClaimCreationDomain>();

            #endregion PackageReclaim

            #region Roles

            CreateMap<Role, RolesDomain>();
            CreateMap<RoleForCreationRequest, RoleForCreationDomain>();
            CreateMap<RoleForUpdateRequest, RoleForUpdateDomain>();
            CreateMap<RoleForCreationDomain, Role>();
            CreateMap<RoleForUpdateDomain, Role>();
            CreateMap<RolesDomain, RoleResponse>();
            CreateMap<AssignRolesToUserRequest, AssignRolesToUserDomain>();
            CreateMap<HackneyTokenRequest, HackneyTokenDomain>();

            #endregion Roles

            #region SupplierBill

            CreateMap<SupplierBillDomain, SupplierBillResponse>();
            CreateMap<SupplierBillItemDomain, SupplierBillItemResponse>();

            #endregion SupplierBill

            #region PrimarySupportReason

            CreateMap<PrimarySupportReason, PrimarySupportReasonDomain>();
            CreateMap<PrimarySupportReasonDomain, PrimarySupportReasonResponse>();

            #endregion PrimarySupportReason

            #region SubmittedPackageRequests

            CreateMap<SubmittedPackageRequestsDomain, SubmittedPackageRequestsResponse>();

            #endregion SubmittedPackageRequests

            #region ApprovedPackages

            CreateMap<ApprovedPackagesDomain, ApprovedPackagesResponse>();

            #endregion ApprovedPackages

            #region BrokeredPackages

            CreateMap<BrokeredPackagesDomain, BrokeredPackagesResponse>();

            #endregion BrokeredPackages

            #region PackageStatus

            CreateMap<PackageStatusOption, StatusDomain>();
            CreateMap<StatusDomain, StatusResponse>();

            #endregion PackageStatus

            #region Invoice

            CreateMap<InvoiceDomain, InvoiceResponse>();
            CreateMap<InvoiceItemDomain, InvoiceItemResponse>();
            CreateMap<InvoiceForCreationRequest, InvoiceResponse>();
            CreateMap<InvoiceItemForCreationRequest, InvoiceItemResponse>();

            CreateMap<InvoiceResponse, InvoiceForCreationRequest>();
            CreateMap<InvoiceItemResponse, InvoiceItemForCreationRequest>();

            #endregion Invoice

            #region Clients

            CreateMap<ClientMinimalDomain, ClientMinimalResponse>();
            CreateMap<ClientsDomain, ClientsResponse>();
            CreateMap<Client, ClientsDomain>();

            #endregion Clients

            #region AdditionalNeedsPaymentType

            CreateMap<AdditionalNeedsPaymentType, AdditionalNeedsPaymentTypeDomain>();
            CreateMap<AdditionalNeedsPaymentTypeDomain, AdditionalNeedsPaymentTypeResponse>();

            #endregion AdditionalNeedsPaymentType

            #region Funded Nursing Care

            CreateMap<FundedNursingCarePrice, FundedNursingCarePriceDomain>();

            #endregion Funded Nursing Care

            #region Care Charges

            CreateMap<ProvisionalCareChargeAmount, ProvisionalCareChargeAmountPlainDomain>();
            CreateMap<ProvisionalCareChargeAmountPlainDomain, ProvisionalCareChargeAmountPlainResponse>().ReverseMap();
            CreateMap<BrokerageCareChargeForChangeRequest, BrokerageCareChargeForChangeDomain>();
            CreateMap<PackageCareCharge, PackageCareChargePlainDomain>();
            CreateMap<PackageCareCharge, PackageCareChargeDomain>();
            CreateMap<InvoiceCreditNote, InvoiceCreditNotePlainDomain>();
            CreateMap<CareChargeElement, CareChargeElementDomain>();

            #endregion Care Charges

            #region Invoicing

            CreateMap<ResidentialCareBrokerageInfo, BrokerageInfo>()
                .ForMember(d => d.Core, opt => opt.MapFrom(s => s.ResidentialCore))
                .ForMember(d => d.AdditionalNeedsCosts, opt => opt.MapFrom(s => s.ResidentialCareAdditionalNeedsCosts));

            CreateMap<ResidentialCareAdditionalNeedsCost, AdditionalNeedsCost>()
                .ForMember(d => d.Cost, opt => opt.MapFrom(s => s.AdditionalNeedsCost));

            #endregion Invoicing

            #region CarePackageReclaim

            CreateMap<FundedNursingCareCreationRequest, CarePackageReclaimCreationDomain>();
            CreateMap<CareChargeReclaimCreationRequest, CarePackageReclaimCreationDomain>();
            CreateMap<FundedNursingCareUpdateRequest, CarePackageReclaimForUpdateDomain>();
            CreateMap<CareChargeReclaimUpdateRequest, CarePackageReclaimForUpdateDomain>();
            CreateMap<CarePackageReclaim, CarePackageReclaimForUpdateDomain>();
            CreateMap<CarePackageReclaimForUpdateDomain, CarePackageReclaim>();
            CreateMap<CareChargePackagesDomain, CareChargePackagesResponse>();
            CreateMap<SinglePackageCareChargeDomain, SinglePackageCareChargeResponse>();

            #endregion
        }
    }
}
