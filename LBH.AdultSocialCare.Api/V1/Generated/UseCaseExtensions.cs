using Microsoft.Extensions.DependencyInjection;
using LBH.AdultSocialCare.Api.V1.UseCase;
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
            services.AddScoped<IDeleteClientsUseCase, DeleteClientsUseCase>();
            services.AddScoped<IGetAllClientsUseCase, GetAllClientsUseCase>();
            services.AddScoped<IGetClientsUseCase, GetClientsUseCase>();
            services.AddScoped<IUpsertClientsUseCase, UpsertClientsUseCase>();
            services.AddScoped<ICareChargeUseCase, CareChargeUseCase>();
            services.AddScoped<ICarePackageOptionsUseCase, CarePackageOptionsUseCase>();
            services.AddScoped<ICreateCarePackageReclaimUseCase, CreateCarePackageReclaimUseCase>();
            services.AddScoped<ICreateCarePackageUseCase, CreateCarePackageUseCase>();
            services.AddScoped<ICreateSupplierUseCase, CreateSupplierUseCase>();
            services.AddScoped<IDeleteStatusUseCase, DeleteStatusUseCase>();
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
            services.AddScoped<IGetServiceUserUseCase, GetServiceUserUseCase>();
            services.AddScoped<IGetSinglePackageCareChargeUseCase, GetSinglePackageCareChargeUseCase>();
            services.AddScoped<IPayRunUseCase, PayRunUseCase>();
            services.AddScoped<ISubmitCarePackageUseCase, SubmitCarePackageUseCase>();
            services.AddScoped<IUpdateCarePackageReclaimUseCase, UpdateCarePackageReclaimUseCase>();
            services.AddScoped<IUpdateCarePackageUseCase, UpdateCarePackageUseCase>();
            services.AddScoped<IUpsertCarePackageBrokerageUseCase, UpsertCarePackageBrokerageUseCase>();
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
