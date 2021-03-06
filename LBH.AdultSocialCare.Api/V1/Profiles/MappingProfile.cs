using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Payments;
using System;

namespace LBH.AdultSocialCare.Api.V1.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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
            CreateMap<SubSupplierDomain, SubSupplierResponse>();

            #endregion Supplier

            #region ServiceUsers

            CreateMap<User, AppUserDomain>();
            CreateMap<AppUserDomain, AppUserResponse>();
            CreateMap<UsersMinimalDomain, UsersMinimalResponse>();

            #endregion ServiceUsers

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

            #region PrimarySupportReason

            CreateMap<PrimarySupportReason, PrimarySupportReasonDomain>();
            CreateMap<PrimarySupportReasonDomain, PrimarySupportReasonResponse>();

            #endregion PrimarySupportReason

            #region Invoice

            CreateMap<InvoiceDomain, InvoiceResponse>();
            CreateMap<InvoiceItemDomain, InvoiceItemResponse>();

            #endregion Invoice

            #region Service Users

            CreateMap<ServiceUserDomain, ServiceUserResponse>();
            CreateMap<ServiceUser, ServiceUserDomain>();

            #endregion Service Users

            #region Funded Nursing Care

            CreateMap<FundedNursingCarePrice, FundedNursingCarePriceDomain>();

            #endregion Funded Nursing Care

            #region Care Charges

            CreateMap<ProvisionalCareChargeAmount, ProvisionalCareChargeAmountPlainDomain>();
            CreateMap<ProvisionalCareChargeAmountPlainDomain, ProvisionalCareChargeAmountPlainResponse>().ReverseMap();
            CreateMap<CareChargeReclaimCreationDomain, CarePackageReclaim>().ReverseMap();
            CreateMap<CareChargeReclaimCreationRequest, CareChargeReclaimCreationDomain>().ReverseMap();

            #endregion Care Charges

            #region Care Package

            CreateMap<CarePackageForCreationRequest, CarePackageForCreationDomain>();

            #endregion Care Package

            #region CarePackageReclaim

            CreateMap<FundedNursingCareCreationRequest, CarePackageReclaimCreationDomain>();
            CreateMap<CareChargeReclaimCreationRequest, CarePackageReclaimCreationDomain>();
            CreateMap<FundedNursingCareUpdateRequest, CarePackageReclaimUpdateDomain>();
            CreateMap<CareChargeReclaimUpdateRequest, CarePackageReclaimUpdateDomain>();
            CreateMap<CarePackageReclaim, CarePackageReclaimUpdateDomain>();
            CreateMap<CarePackageReclaimUpdateDomain, CarePackageReclaim>();
            CreateMap<CareChargePackagesDomain, CareChargePackagesResponse>();
            CreateMap<SinglePackageCareChargeDomain, SinglePackageCareChargeResponse>();
            CreateMap<CareChargeReclaimBulkUpdateRequest, CareChargeReclaimBulkUpdateDomain>();
            CreateMap<CareChargeReclaimUpdateRequest, CarePackageReclaimUpdateDomain>();

            #endregion CarePackageReclaim

            #region PayRun

            CreateMap<Payrun, DraftPayRunCreationDomain>().ReverseMap();

            #endregion PayRun

        }
    }
}
