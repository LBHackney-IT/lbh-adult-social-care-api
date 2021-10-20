using Microsoft.Extensions.DependencyInjection;
using LBH.AdultSocialCare.Api.V1.UseCase;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class UseCaseExtensions
    {
        public static void RegisterUseCases(this IServiceCollection services)
        {
            services.AddScoped<IApproveCarePackageUseCase, ApproveCarePackageUseCase>();
            services.AddScoped<IAssignCarePlanUseCase, AssignCarePlanUseCase>();
            services.AddScoped<ICancelCarePackageUseCase, CancelCarePackageUseCase>();
            services.AddScoped<ICarePackageOptionsUseCase, CarePackageOptionsUseCase>();
            services.AddScoped<ICreateCarePackageReclaimUseCase, CreateCarePackageReclaimUseCase>();
            services.AddScoped<ICreateCarePackageUseCase, CreateCarePackageUseCase>();
            services.AddScoped<IDeclineCarePackageUseCase, DeclineCarePackageUseCase>();
            services.AddScoped<IEndCarePackageUseCase, EndCarePackageUseCase>();
            services.AddScoped<IGetCareChargePackagesUseCase, GetCareChargePackagesUseCase>();
            services.AddScoped<IGetCarePackageBrokerageUseCase, GetCarePackageBrokerageUseCase>();
            services.AddScoped<IGetCarePackageHistoryUseCase, GetCarePackageHistoryUseCase>();
            services.AddScoped<IGetCarePackageReclaimUseCase, GetCarePackageReclaimUseCase>();
            services.AddScoped<IGetCarePackageSummaryUseCase, GetCarePackageSummaryUseCase>();
            services.AddScoped<IGetCarePackageUseCase, GetCarePackageUseCase>();
            services.AddScoped<IGetSinglePackageCareChargeUseCase, GetSinglePackageCareChargeUseCase>();
            services.AddScoped<ISubmitCarePackageUseCase, SubmitCarePackageUseCase>();
            services.AddScoped<IUpdateCarePackageReclaimUseCase, UpdateCarePackageReclaimUseCase>();
            services.AddScoped<IUpdateCarePackageUseCase, UpdateCarePackageUseCase>();
            services.AddScoped<IUpsertCarePackageBrokerageUseCase, UpsertCarePackageBrokerageUseCase>();
            services.AddScoped<IDeleteClientsUseCase, DeleteClientsUseCase>();
            services.AddScoped<IGetClientsUseCase, GetClientsUseCase>();
            services.AddScoped<IGetServiceUserMasterSearchUseCase, GetServiceUserMasterSearchUseCase>();
            services.AddScoped<IGetServiceUserSearchUseCase, GetServiceUserSearchUseCase>();
            services.AddScoped<IGetServiceUsersUseCase, GetServiceUsersUseCase>();
            services.AddScoped<IUpsertClientsUseCase, UpsertClientsUseCase>();
            services.AddScoped<ICareChargeUseCase, CareChargeUseCase>();
            services.AddScoped<IConfirmS117ServiceUserUseCase, ConfirmS117ServiceUserUseCase>();
            services.AddScoped<ICreateSupplierUseCase, CreateSupplierUseCase>();
            services.AddScoped<IGetAllPrimarySupportReasonsUseCase, GetAllPrimarySupportReasonsUseCase>();
            services.AddScoped<IGetAllStatusUseCase, GetAllStatusUseCase>();
            services.AddScoped<IGetAllSupplierUseCase, GetAllSupplierUseCase>();
            services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
            services.AddScoped<IGetFundedNursingCarePriceUseCase, GetFundedNursingCarePriceUseCase>();
            services.AddScoped<IGetServiceUserUseCase, GetServiceUserUseCase>();
            services.AddScoped<IPayRunUseCase, PayRunUseCase>();
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
