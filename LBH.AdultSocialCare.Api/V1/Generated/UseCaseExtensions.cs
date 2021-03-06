using Microsoft.Extensions.DependencyInjection;
using LBH.AdultSocialCare.Api.V1.UseCase;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;
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
            services.AddScoped<ICancelCareChargeUseCase, CancelCareChargeUseCase>();
            services.AddScoped<ICancelCarePackageUseCase, CancelCarePackageUseCase>();
            services.AddScoped<ICarePackageOptionsUseCase, CarePackageOptionsUseCase>();
            services.AddScoped<ICreateCarePackageUseCase, CreateCarePackageUseCase>();
            services.AddScoped<ICreateFundedNursingCareUseCase, CreateFundedNursingCareUseCase>();
            services.AddScoped<ICreatePackageResourceUseCase, CreatePackageResourceUseCase>();
            services.AddScoped<ICreateProvisionalCareChargeUseCase, CreateProvisionalCareChargeUseCase>();
            services.AddScoped<IDeclineCarePackageUseCase, DeclineCarePackageUseCase>();
            services.AddScoped<IDeleteCarePackageUseCase, DeleteCarePackageUseCase>();
            services.AddScoped<IEndCareChargeUseCase, EndCareChargeUseCase>();
            services.AddScoped<IEndCarePackageUseCase, EndCarePackageUseCase>();
            services.AddScoped<IEnsureSingleActivePackageTypePerUserUseCase, EnsureSingleActivePackageTypePerUserUseCase>();
            services.AddScoped<IGetApprovableCarePackagesUseCase, GetApprovableCarePackagesUseCase>();
            services.AddScoped<IGetCareChargePackagesUseCase, GetCareChargePackagesUseCase>();
            services.AddScoped<IGetCarePackageBrokerageUseCase, GetCarePackageBrokerageUseCase>();
            services.AddScoped<IGetCarePackageHistoryUseCase, GetCarePackageHistoryUseCase>();
            services.AddScoped<IGetCarePackageReclaimsUseCase, GetCarePackageReclaimsUseCase>();
            services.AddScoped<IGetCarePackageSummaryUseCase, GetCarePackageSummaryUseCase>();
            services.AddScoped<IGetCarePackageUseCase, GetCarePackageUseCase>();
            services.AddScoped<IGetServiceUserPackagesUseCase, GetServiceUserPackagesUseCase>();
            services.AddScoped<IGetSinglePackageCareChargeUseCase, GetSinglePackageCareChargeUseCase>();
            services.AddScoped<ISubmitCarePackageUseCase, SubmitCarePackageUseCase>();
            services.AddScoped<IUpdateCarePackageUseCase, UpdateCarePackageUseCase>();
            services.AddScoped<IUpdateFundedNursingCareUseCase, UpdateFundedNursingCareUseCase>();
            services.AddScoped<IUpdateProvisionalCareChargeUseCase, UpdateProvisionalCareChargeUseCase>();
            services.AddScoped<IUpsertCareChargesUseCase, UpsertCareChargesUseCase>();
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
            services.AddScoped<IApprovePayRunUseCase, ApprovePayRunUseCase>();
            services.AddScoped<IArchivePayRunUseCase, ArchivePayRunUseCase>();
            services.AddScoped<IChangePayRunInvoiceStatusUseCase, ChangePayRunInvoiceStatusUseCase>();
            services.AddScoped<ICreateDraftPayRunUseCase, CreateDraftPayRunUseCase>();
            services.AddScoped<IDownloadPayRunCedarFileUseCase, DownloadPayRunCedarFileUseCase>();
            services.AddScoped<IGetDepartmentUseCase, GetDepartmentUseCase>();
            services.AddScoped<IGetEndDateOfLastPayRunUseCase, GetEndDateOfLastPayRunUseCase>();
            services.AddScoped<IGetHeldInvoicesUseCase, GetHeldInvoicesUseCase>();
            services.AddScoped<IGetPackagePaymentHistoryUseCase, GetPackagePaymentHistoryUseCase>();
            services.AddScoped<IGetPayRunDetailsUseCase, GetPayRunDetailsUseCase>();
            services.AddScoped<IGetPayRunInsightsUseCase, GetPayRunInsightsUseCase>();
            services.AddScoped<IGetPayRunInvoiceUseCase, GetPayRunInvoiceUseCase>();
            services.AddScoped<IGetPayRunListUseCase, GetPayRunListUseCase>();
            services.AddScoped<IGetReleasedInvoiceCountUseCase, GetReleasedInvoiceCountUseCase>();
            services.AddScoped<IHoldInvoiceUseCase, HoldInvoiceUseCase>();
            services.AddScoped<IMakePayRunPaymentUseCase, MakePayRunPaymentUseCase>();
            services.AddScoped<ISubmitPayRunUseCase, SubmitPayRunUseCase>();
            services.AddScoped<IAuthUseCase, AuthUseCase>();
            services.AddScoped<IGetAllRoleUseCase, GetAllRoleUseCase>();
            services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
            services.AddScoped<IIdentityHelperUseCase, IdentityHelperUseCase>();
        }
    }
}
