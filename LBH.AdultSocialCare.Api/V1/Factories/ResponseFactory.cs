using AutoMapper;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Data.Constants.Enums;
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

        #region PrimaryReasonSupport

        public static IEnumerable<PrimarySupportReasonResponse> ToResponse(this IEnumerable<PrimarySupportReasonDomain> primarySupportReasonDomains)
        {
            return _mapper.Map<IEnumerable<PrimarySupportReasonResponse>>(primarySupportReasonDomains);
        }

        #endregion PrimaryReasonSupport

        #region Invoice

        public static InvoiceResponse ToResponse(this InvoiceDomain invoiceDomain)
        {
            return _mapper.Map<InvoiceResponse>(invoiceDomain);
        }

        #endregion Invoice

        #region Service Users

        public static IEnumerable<ServiceUserResponse> ToResponse(this IEnumerable<ServiceUserDomain> serviceUsersDomain)
        {
            return _mapper.Map<IEnumerable<ServiceUserResponse>>(serviceUsersDomain);
        }

        #endregion Service Users

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

        #region Payments

        public static PayRunInvoiceResponse ToResponse(this PayRunInvoiceDomain invoice, InvoiceStatus status, decimal supplierReclaimsTotal, decimal hackneyReclaimsTotal)
        {
            return new PayRunInvoiceResponse
            {
                Id = invoice.Id,
                InvoiceId = invoice.InvoiceId,
                CarePackageId = invoice.CarePackageId,
                ServiceUserId = invoice.ServiceUserId,
                HackneyId = invoice.HackneyId,
                ServiceUserName = invoice.ServiceUserName,
                SupplierId = invoice.SupplierId,
                SupplierName = invoice.SupplierName,
                InvoiceNumber = invoice.InvoiceNumber,
                PackageTypeId = (int) invoice.PackageType,
                PackageType = invoice.PackageType.GetDisplayName(),
                GrossTotal = decimal.Round(invoice.GrossTotal, 2),
                NetTotal = decimal.Round(invoice.NetTotal, 2),
                SupplierReclaimsTotal = decimal.Round(supplierReclaimsTotal, 2),
                HackneyReclaimsTotal = decimal.Round(hackneyReclaimsTotal, 2),
                InvoiceStatus = status,
                AssignedBrokerName = invoice.AssignedBrokerName,
                InvoiceItems = invoice.InvoiceItems.ToResponse()
            };
        }

        #endregion Payments
    }
}
