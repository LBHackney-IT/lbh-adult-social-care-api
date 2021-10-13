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
