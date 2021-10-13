using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Factories
{
    public static class ResponseFactory
    {
        private static IMapper _mapper { get; set; }

        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }

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
