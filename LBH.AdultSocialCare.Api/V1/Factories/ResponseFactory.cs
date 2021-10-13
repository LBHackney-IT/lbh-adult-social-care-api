using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System.Collections.Generic;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ResponseFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region TermTimeConsiderations

        public static IEnumerable<TermTimeConsiderationOptionResponse> ToResponse(this IEnumerable<TermTimeConsiderationOptionDomain> termTimeConsiderationDomains)
        {
            return _mapper.Map<IEnumerable<TermTimeConsiderationOptionResponse>>(termTimeConsiderationDomains);
        }

        #endregion TermTimeConsiderations

        #region OpportunityLengthOptions

        public static IEnumerable<OpportunityLengthOptionResponse> ToResponse(this IEnumerable<OpportunityLengthOptionDomain> opportunityLengthOptionDomains)
        {
            return _mapper.Map<IEnumerable<OpportunityLengthOptionResponse>>(opportunityLengthOptionDomains);
        }

        #endregion OpportunityLengthOptions

        #region OpportunityTimesPerMonthOptions

        public static IEnumerable<OpportunityTimesPerMonthOptionResponse> ToResponse(this IEnumerable<OpportunityTimesPerMonthOptionDomain> opportunityTimesPerMonthOptionDomains)
        {
            return _mapper.Map<IEnumerable<OpportunityTimesPerMonthOptionResponse>>(opportunityTimesPerMonthOptionDomains);
        }

        #endregion OpportunityTimesPerMonthOptions

        #region ResidentialCarePackage

        public static ResidentialCarePackageResponse ToResponse(this ResidentialCarePackageDomain residentialCarePackageDomain)
        {
            // return _mapper.Map<NursingCarePackageResponse>(nursingCarePackageDomain);
            return new ResidentialCarePackageResponse
            {
                Id = residentialCarePackageDomain.Id,
                ClientId = residentialCarePackageDomain.ClientId,
                IsFixedPeriod = residentialCarePackageDomain.IsFixedPeriod,
                StartDate = residentialCarePackageDomain.StartDate,
                EndDate = residentialCarePackageDomain.EndDate,
                HasRespiteCare = residentialCarePackageDomain.HasRespiteCare,
                HasDischargePackage = residentialCarePackageDomain.HasDischargePackage,
                IsThisAnImmediateService = residentialCarePackageDomain.IsThisAnImmediateService,
                IsThisUserUnderS117 = residentialCarePackageDomain.IsThisUserUnderS117,
                TypeOfStayId = residentialCarePackageDomain.TypeOfStayId,
                NeedToAddress = residentialCarePackageDomain.NeedToAddress,
                TypeOfResidentialCareHomeId = residentialCarePackageDomain.TypeOfResidentialCareHomeId,
                CreatorId = residentialCarePackageDomain.CreatorId,
                UpdaterId = residentialCarePackageDomain.UpdaterId,
                StatusId = residentialCarePackageDomain.StatusId,
                ClientName = residentialCarePackageDomain.ClientName,
                ClientHackneyId = residentialCarePackageDomain.ClientHackneyId,
                ClientPostCode = residentialCarePackageDomain.ClientPostCode,
                ClientDateOfBirth = residentialCarePackageDomain.ClientDateOfBirth,
                ClientCanSpeakEnglish = residentialCarePackageDomain.ClientCanSpeakEnglish,
                ClientPreferredContact = residentialCarePackageDomain.ClientPreferredContact,
                StatusName = residentialCarePackageDomain.StatusName,
                CreatorName = residentialCarePackageDomain.CreatorName,
                UpdaterName = residentialCarePackageDomain.UpdaterName,
                PackageName = residentialCarePackageDomain.PackageName,
                TypeOfCareHomeName = residentialCarePackageDomain.TypeOfCareHomeName,
                TypeOfStayOptionName = residentialCarePackageDomain.TypeOfStayOptionName,
                ResidentialCareAdditionalNeeds = residentialCarePackageDomain.ResidentialCareAdditionalNeeds.ToResponse()
            };
        }

        public static IEnumerable<ResidentialCarePackageResponse> ToResponse(this IEnumerable<ResidentialCarePackageDomain> residentialCarePackageDomains)
        {
            return _mapper.Map<IEnumerable<ResidentialCarePackageResponse>>(residentialCarePackageDomains);
        }

        #endregion ResidentialCarePackage

        #region ResidentialCareAdditionalNeed

        public static IEnumerable<ResidentialCareAdditionalNeedsResponse> ToResponse(this IEnumerable<ResidentialCareAdditionalNeedsDomain> residentialCareAdditionalNeedsDomain)
        {
            return _mapper.Map<IEnumerable<ResidentialCareAdditionalNeedsResponse>>(residentialCareAdditionalNeedsDomain);
        }

        #endregion ResidentialCareAdditionalNeed

        #region ResidentialCareTypeOfStayOptions

        public static IEnumerable<ResidentialCareTypeOfStayOptionResponse> ToResponse(this IEnumerable<ResidentialCareTypeOfStayOptionDomain> residentialCareTypeOfStayOptionDomains)
        {
            return residentialCareTypeOfStayOptionDomains.Select(item
                => new ResidentialCareTypeOfStayOptionResponse
                {
                    TypeOfStayOptionId = item.TypeOfStayOptionId,
                    OptionName = item.OptionName,
                    OptionPeriod = item.OptionPeriod
                }).ToList();
        }

        #endregion ResidentialCareTypeOfStayOptions

        public static IEnumerable<TypeOfResidentialCareHomeResponse> ToResponse(this IEnumerable<TypeOfResidentialCareHomeDomain> typeOfResidentialCareHomeDomain)
        {
            return _mapper.Map<IEnumerable<TypeOfResidentialCareHomeResponse>>(typeOfResidentialCareHomeDomain);
        }

        #region Supplier

        public static SupplierResponse ToResponse(this SupplierDomain supplierDomain)
        {
            return _mapper.Map<SupplierResponse>(supplierDomain);
        }

        public static IEnumerable<SupplierResponse> ToResponse(this IEnumerable<SupplierDomain> supplierDomain)
        {
            return _mapper.Map<IEnumerable<SupplierResponse>>(supplierDomain);
        }

        #endregion Supplier

        #region ResidentialCareApprovePackage

        public static ResidentialCareApprovePackageResponse ToResponse(this ResidentialCareApprovePackageDomain residentialCareApprovePackageDomain)
        {
            return _mapper.Map<ResidentialCareApprovePackageResponse>(residentialCareApprovePackageDomain);
        }

        #endregion ResidentialCareApprovePackage

        #region ResidentialCareApproveBrokered

        public static ResidentialCareApproveBrokeredResponse ToResponse(this ResidentialCareApproveBrokeredDomain residentialCareApproveBrokeredDomain)
        {
            return _mapper.Map<ResidentialCareApproveBrokeredResponse>(residentialCareApproveBrokeredDomain);
        }

        #endregion ResidentialCareApproveBrokered

        #region ResidentialCareBrokerage

        public static IEnumerable<ResidentialCareApprovalHistoryResponse> ToResponse(this IEnumerable<ResidentialCareApprovalHistoryDomain> residentialCareApprovalHistoryDomain)
        {
            return _mapper.Map<IEnumerable<ResidentialCareApprovalHistoryResponse>>(residentialCareApprovalHistoryDomain);
        }

        public static ResidentialCareBrokerageInfoResponse ToResponse(this ResidentialCareBrokerageInfoDomain residentialCareBrokerageInfoDomain)
        {
            return _mapper.Map<ResidentialCareBrokerageInfoResponse>(residentialCareBrokerageInfoDomain);
        }

        #endregion ResidentialCareBrokerage

        #region PackageReclaim

        public static IEnumerable<ReclaimFromResponse> ToResponse(this IEnumerable<ReclaimFromDomain> reclaimFromDomain)
        {
            return _mapper.Map<IEnumerable<ReclaimFromResponse>>(reclaimFromDomain);
        }

        public static IEnumerable<ReclaimCategoryResponse> ToResponse(this IEnumerable<ReclaimCategoryDomain> homeCarePackageReclaimCategoryDomain)
        {
            return _mapper.Map<IEnumerable<ReclaimCategoryResponse>>(homeCarePackageReclaimCategoryDomain);
        }

        public static IEnumerable<ReclaimAmountOptionResponse> ToResponse(this IEnumerable<ReclaimAmountOptionDomain> reclaimAmountOptionDomain)
        {
            return _mapper.Map<IEnumerable<ReclaimAmountOptionResponse>>(reclaimAmountOptionDomain);
        }

        public static ResidentialCarePackageClaimResponse ToResponse(this ResidentialCarePackageClaimDomain residentialCarePackageClaimDomain)
        {
            return _mapper.Map<ResidentialCarePackageClaimResponse>(residentialCarePackageClaimDomain);
        }

        #endregion PackageReclaim

        #region Packages

        public static PackageResponse ToResponse(this PackageTypeDomain packageTypeDomain)
        {
            return new PackageResponse
            {
                Id = packageTypeDomain.Id,
                PackageName = packageTypeDomain.PackageType,
                Sequence = packageTypeDomain.Sequence
            };
        }

        #endregion Packages

        #region ResidentialCareAdditionalNeeds

        public static ResidentialCareAdditionalNeedsResponse ToResponse(this ResidentialCareAdditionalNeedsDomain residentialCareAdditionalNeedsDomain)
        {
            return new ResidentialCareAdditionalNeedsResponse
            {
                Id = residentialCareAdditionalNeedsDomain.Id,
                ResidentialCarePackageId = residentialCareAdditionalNeedsDomain.ResidentialCarePackageId,
                AdditionalNeedsPaymentTypeId = residentialCareAdditionalNeedsDomain.AdditionalNeedsPaymentTypeId,
                AdditionalNeedsPaymentTypeName = residentialCareAdditionalNeedsDomain.AdditionalNeedsPaymentTypeName,
                NeedToAddress = residentialCareAdditionalNeedsDomain.NeedToAddress,
                CreatorId = residentialCareAdditionalNeedsDomain.CreatorId,
                UpdatorId = residentialCareAdditionalNeedsDomain.UpdatorId,
            };
        }

        #endregion ResidentialCareAdditionalNeeds

        #region ResidentialCarePackage

        public static IList<ResidentialCarePackageResponse> ToResponse(this IList<CarePackageForCreationDomain> residentialCarePackagesDomain)
        {
            return _mapper.Map<IList<ResidentialCarePackageResponse>>(residentialCarePackagesDomain);
        }

        public static IList<TypeOfResidentialCareHomeResponse> ToResponse(this IList<TypeOfResidentialCareHomeDomain> typeOfResidentialCareHomesDomain)
        {
            return typeOfResidentialCareHomesDomain.Select(item
                => new TypeOfResidentialCareHomeResponse
                {
                    TypeOfCareHomeId = item.TypeOfCareHomeId,
                    TypeOfCareHomeName = item.TypeOfCareHomeName
                }).ToList();
        }

        #endregion ResidentialCarePackage

        #region Roles

        public static RoleResponse ToResponse(this RolesDomain rolesDomain)
        {
            return new RoleResponse
            {
                Id = rolesDomain.Id,
                ConcurrencyStamp = rolesDomain.ConcurrencyStamp,
                Name = rolesDomain.Name,
                NormalizedName = rolesDomain.NormalizedName
            };
        }

        public static IList<RoleResponse> ToResponse(this IList<RolesDomain> roleDomains)
        {
            return _mapper.Map<IList<RoleResponse>>(roleDomains);
        }

        #endregion Roles

        #region ServiceUsers

        public static IEnumerable<UsersMinimalResponse> ToResponse(this IEnumerable<UsersMinimalDomain> usersDomains)
        {
            return _mapper.Map<IEnumerable<UsersMinimalResponse>>(usersDomains);
        }

        #endregion ServiceUsers

        #region PackageStatus

        public static StatusResponse ToResponse(this StatusDomain statusDomain)
        {
            return new StatusResponse
            {
                Id = statusDomain.Id,
                StatusName = statusDomain.StatusName,
                CreatorId = statusDomain.CreatorId,
                UpdaterId = statusDomain.UpdaterId
            };
        }

        public static IEnumerable<StatusResponse> ToResponse(this IEnumerable<StatusDomain> statusDomains)
        {
            return _mapper.Map<IEnumerable<StatusResponse>>(statusDomains);
        }

        #endregion PackageStatus

        #region TimeSlotShifts

        public static TimeSlotShiftsResponse ToResponse(this TimeSlotShiftsDomain timeSlotShiftsDomain)
        {
            return new TimeSlotShiftsResponse
            {
                Id = timeSlotShiftsDomain.Id,
                TimeSlotShiftName = timeSlotShiftsDomain.TimeSlotShiftName,
                TimeSlotTimeLabel = timeSlotShiftsDomain.TimeSlotTimeLabel,
                CreatorId = timeSlotShiftsDomain.CreatorId,
                DateCreated = timeSlotShiftsDomain.DateCreated,
                UpdaterId = timeSlotShiftsDomain.UpdaterId,
                DateUpdated = timeSlotShiftsDomain.DateUpdated
            };
        }

        #endregion TimeSlotShifts

        #region SupplierBill

        public static SupplierBillResponse ToResponse(this SupplierBillDomain supplierBillDomain)
        {
            return _mapper.Map<SupplierBillResponse>(supplierBillDomain);
        }

        #endregion SupplierBill

        #region PrimaryReasonSupport

        public static IEnumerable<PrimarySupportReasonResponse> ToResponse(this IEnumerable<PrimarySupportReasonDomain> primarySupportReasonDomains)
        {
            return _mapper.Map<IEnumerable<PrimarySupportReasonResponse>>(primarySupportReasonDomains);
        }

        #endregion PrimaryReasonSupport

        #region SubmittedPackageRequests

        public static IEnumerable<SubmittedPackageRequestsResponse> ToResponse(this IEnumerable<SubmittedPackageRequestsDomain> submittedPackageRequestsDomains)
        {
            return _mapper.Map<IEnumerable<SubmittedPackageRequestsResponse>>(submittedPackageRequestsDomains);
        }

        #endregion SubmittedPackageRequests

        #region ApprovedPackages

        public static IEnumerable<ApprovedPackagesResponse> ToResponse(this IEnumerable<ApprovedPackagesDomain> approvedPackagesDomains)
        {
            return _mapper.Map<IEnumerable<ApprovedPackagesResponse>>(approvedPackagesDomains);
        }

        #endregion ApprovedPackages

        #region ApprovedPackages

        public static IEnumerable<BrokeredPackagesResponse> ToResponse(this IEnumerable<BrokeredPackagesDomain> brokeredPackagesDomains)
        {
            return _mapper.Map<IEnumerable<BrokeredPackagesResponse>>(brokeredPackagesDomains);
        }

        #endregion ApprovedPackages

        #region Invoice

        public static InvoiceResponse ToResponse(this InvoiceDomain invoiceDomain)
        {
            return _mapper.Map<InvoiceResponse>(invoiceDomain);
        }

        #endregion Invoice

        #region Clients

        public static ClientMinimalResponse ToResponse(this ClientMinimalDomain clientMinimalDomain)
        {
            return _mapper.Map<ClientMinimalResponse>(clientMinimalDomain);
        }

        public static IEnumerable<ClientMinimalResponse> ToResponse(this IEnumerable<ClientMinimalDomain> clientMinimalDomain)
        {
            return _mapper.Map<IEnumerable<ClientMinimalResponse>>(clientMinimalDomain);
        }

        public static IEnumerable<ClientsResponse> ToResponse(this IEnumerable<ClientsDomain> clientsDomain)
        {
            return _mapper.Map<IEnumerable<ClientsResponse>>(clientsDomain);
        }

        #endregion Clients

        #region FncCollectors

        public static IEnumerable<FundedNursingCareCollectorResponse> ToResponse(this IEnumerable<FundedNursingCareCollectorDomain> collectors)
        {
            return _mapper.Map<IEnumerable<FundedNursingCareCollectorResponse>>(collectors);
        }

        #endregion FncCollectors

        #region CareCharges

        public static ProvisionalCareChargeAmountPlainResponse ToResponse(this ProvisionalCareChargeAmountPlainDomain provisionalCareChargeDomain)
        {
            return _mapper.Map<ProvisionalCareChargeAmountPlainResponse>(provisionalCareChargeDomain);
        }

        public static IEnumerable<CareChargePackagesResponse> ToResponse(this IEnumerable<CareChargePackagesDomain> careChargePackagesDomains)
        {
            return _mapper.Map<IEnumerable<CareChargePackagesResponse>>(careChargePackagesDomains);
        }

        public static SinglePackageCareChargeResponse ToResponse(this SinglePackageCareChargeDomain singlePackageCareChargeDomain)
        {
            return _mapper.Map<SinglePackageCareChargeResponse>(singlePackageCareChargeDomain);
        }

        #endregion CareCharges
    }
}
