using AutoMapper;
using HttpServices.Models.Requests;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

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

            #region Funded Nursing Care

            CreateMap<FundedNursingCarePrice, FundedNursingCarePriceDomain>();

            #endregion Funded Nursing Care

            #region Care Charges

            CreateMap<ProvisionalCareChargeAmount, ProvisionalCareChargeAmountPlainDomain>();
            CreateMap<ProvisionalCareChargeAmountPlainDomain, ProvisionalCareChargeAmountPlainResponse>().ReverseMap();

            #endregion Care Charges

            #region Care Package

            CreateMap<CarePackageForCreationRequest, CarePackageForCreationDomain>();

            #endregion Care Package

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
