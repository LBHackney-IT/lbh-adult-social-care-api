using Microsoft.Extensions.DependencyInjection;
using LBH.AdultSocialCare.Api.V1.UseCase;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class UseCaseExtensions
    {
        public static void RegisterUseCases(this IServiceCollection services)
        {
            services.AddScoped<IDeleteClientsUseCase, DeleteClientsUseCase>();
            services.AddScoped<IGetAllClientsUseCase, GetAllClientsUseCase>();
            services.AddScoped<IGetClientsUseCase, GetClientsUseCase>();
            services.AddScoped<IUpsertClientsUseCase, UpsertClientsUseCase>();
            services.AddScoped<ICancelOrEndCareChargeElementUseCase, CancelOrEndCareChargeElementUseCase>();
            services.AddScoped<ICareChargeElementTypeUseCase, CareChargeElementTypeUseCase>();
            services.AddScoped<ICareChargeUseCase, CareChargeUseCase>();
            services.AddScoped<ICarePackageOptionsUseCase, CarePackageOptionsUseCase>();
            services.AddScoped<ICreateCareChargeElementUseCase, CreateCareChargeElementUseCase>();
            services.AddScoped<ICreateCarePackageReclaimUseCase, CreateCarePackageReclaimUseCase>();
            services.AddScoped<ICreateCarePackageUseCase, CreateCarePackageUseCase>();
            services.AddScoped<ICreateSupplierUseCase, CreateSupplierUseCase>();
            services.AddScoped<IDeletePackageUseCase, DeletePackageUseCase>();
            services.AddScoped<IDeleteStatusUseCase, DeleteStatusUseCase>();
            services.AddScoped<IEditCareChargeElementUseCase, EditCareChargeElementUseCase>();
            services.AddScoped<IGetAllPrimarySupportReasonsUseCase, GetAllPrimarySupportReasonsUseCase>();
            services.AddScoped<IGetAllStatusUseCase, GetAllStatusUseCase>();
            services.AddScoped<IGetAllSupplierUseCase, GetAllSupplierUseCase>();
            services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
            services.AddScoped<IGetCareChargePackagesUseCase, GetCareChargePackagesUseCase>();
            services.AddScoped<IGetCarePackageBrokerageUseCase, GetCarePackageBrokerageUseCase>();
            services.AddScoped<IGetCarePackageReclaimUseCase, GetCarePackageReclaimUseCase>();
            services.AddScoped<IGetCarePackageSummaryUseCase, GetCarePackageSummaryUseCase>();
            services.AddScoped<IGetCarePackageUseCase, GetCarePackageUseCase>();
            services.AddScoped<IGetFundedNursingCarePriceUseCase, GetFundedNursingCarePriceUseCase>();
            services.AddScoped<IGetOpportunityLengthOptionsListUseCase, GetOpportunityLengthOptionsListUseCase>();
            services.AddScoped<IGetOpportunityTimesPerMonthOptionsListUseCase, GetOpportunityTimesPerMonthOptionsListUseCase>();
            services.AddScoped<IGetPackageTypeUseCase, GetPackageTypeUseCase>();
            services.AddScoped<IGetServiceUserUseCase, GetServiceUserUseCase>();
            services.AddScoped<IGetSinglePackageCareChargeUseCase, GetSinglePackageCareChargeUseCase>();
            services.AddScoped<IGetStatusUseCase, GetStatusUseCase>();
            services.AddScoped<IGetTermTimeConsiderationOptionsListUseCase, GetTermTimeConsiderationOptionsListUseCase>();
            services.AddScoped<IPayRunUseCase, PayRunUseCase>();
            services.AddScoped<ISubmitCarePackageUseCase, SubmitCarePackageUseCase>();
            services.AddScoped<IUpdateCarePackageReclaimUseCase, UpdateCarePackageReclaimUseCase>();
            services.AddScoped<IUpdateCarePackageUseCase, UpdateCarePackageUseCase>();
            services.AddScoped<IUpsertCarePackageBrokerageUseCase, UpsertCarePackageBrokerageUseCase>();
            services.AddScoped<IUpsertPackageUseCase, UpsertPackageUseCase>();
            services.AddScoped<IUpsertStatusUseCase, UpsertStatusUseCase>();
            services.AddScoped<IChangeDatesOfResidentialCarePackageUseCase, ChangeDatesOfResidentialCarePackageUseCase>();
            services.AddScoped<IChangeStatusResidentialCarePackageUseCase, ChangeStatusResidentialCarePackageUseCase>();
            services.AddScoped<ICreateResidentialCareBrokerageUseCase, CreateResidentialCareBrokerageUseCase>();
            services.AddScoped<ICreateResidentialCarePackageReclaimUseCase, CreateResidentialCarePackageReclaimUseCase>();
            services.AddScoped<ICreateResidentialCarePackageUseCase, CreateResidentialCarePackageUseCase>();
            services.AddScoped<ICreateResidentialCareRequestMoreInformationUseCase, CreateResidentialCareRequestMoreInformationUseCase>();
            services.AddScoped<IDeleteResidentialCareAdditionalNeedsUseCase, DeleteResidentialCareAdditionalNeedsUseCase>();
            services.AddScoped<IGetAllResidentialCareApprovalHistoryUseCase, GetAllResidentialCareApprovalHistoryUseCase>();
            services.AddScoped<IGetAllResidentialCareHomeTypeUseCase, GetAllResidentialCareHomeTypeUseCase>();
            services.AddScoped<IGetAllResidentialCarePackageUseCase, GetAllResidentialCarePackageUseCase>();
            services.AddScoped<IGetAllResidentialCareTypeOfStayOptionUseCase, GetAllResidentialCareTypeOfStayOptionUseCase>();
            services.AddScoped<IGetResidentialCareAdditionalNeedsUseCase, GetResidentialCareAdditionalNeedsUseCase>();
            services.AddScoped<IGetResidentialCareApproveBrokeredUseCase, GetResidentialCareApproveBrokeredUseCase>();
            services.AddScoped<IGetResidentialCareApprovePackageUseCase, GetResidentialCareApprovePackageUseCase>();
            services.AddScoped<IGetResidentialCareBrokerageUseCase, GetResidentialCareBrokerageUseCase>();
            services.AddScoped<IGetResidentialCareInvoiceDetailUseCase, GetResidentialCareInvoiceDetailUseCase>();
            services.AddScoped<IGetResidentialCarePackageUseCase, GetResidentialCarePackageUseCase>();
            services.AddScoped<ISetStageToResidentialCarePackageUseCase, SetStageToResidentialCarePackageUseCase>();
            services.AddScoped<IUpdateResidentialCarePackageUseCase, UpdateResidentialCarePackageUseCase>();
            services.AddScoped<IUpsertResidentialCareAdditionalNeedsUseCase, UpsertResidentialCareAdditionalNeedsUseCase>();
            services.AddScoped<IAuthUseCase, AuthUseCase>();
            services.AddScoped<IDeleteRoleUseCase, DeleteRoleUseCase>();
            services.AddScoped<IDeleteUsersUseCase, DeleteUsersUseCase>();
            services.AddScoped<IGetAllRoleUseCase, GetAllRoleUseCase>();
            services.AddScoped<IGetRoleUseCase, GetRoleUseCase>();
            services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
            services.AddScoped<IIdentityHelperUseCase, IdentityHelperUseCase>();
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IUpsertRoleUseCase, UpsertRoleUseCase>();
        }
    }
}
