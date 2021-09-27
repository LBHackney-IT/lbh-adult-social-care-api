using Microsoft.Extensions.DependencyInjection;
using LBH.AdultSocialCare.Api.V1.UseCase;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Clients.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCare.Interfaces;
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
            services.AddScoped<IGetClientPackagesCountUseCase, GetClientPackagesCountUseCase>();
            services.AddScoped<IGetClientsUseCase, GetClientsUseCase>();
            services.AddScoped<IUpsertClientsUseCase, UpsertClientsUseCase>();
            services.AddScoped<IAssignToUserUseCase, AssignToUserUseCase>();
            services.AddScoped<ICancelOrEndCareChargeElementUseCase, CancelOrEndCareChargeElementUseCase>();
            services.AddScoped<ICareChargeElementTypeUseCase, CareChargeElementTypeUseCase>();
            services.AddScoped<ICareChargeUseCase, CareChargeUseCase>();
            services.AddScoped<ICarePackageBrokerageUseCase, CarePackageBrokerageUseCase>();
            services.AddScoped<ICreateCareChargeElementUseCase, CreateCareChargeElementUseCase>();
            services.AddScoped<ICreateCarePackageReclaimUseCase, CreateCarePackageReclaimUseCase>();
            services.AddScoped<ICreateCarePackageUseCase, CreateCarePackageUseCase>();
            services.AddScoped<ICreateSupplierCostUseCase, CreateSupplierCostUseCase>();
            services.AddScoped<ICreateSupplierUseCase, CreateSupplierUseCase>();
            services.AddScoped<IDeletePackageUseCase, DeletePackageUseCase>();
            services.AddScoped<IDeleteStatusUseCase, DeleteStatusUseCase>();
            services.AddScoped<IEditCareChargeElementUseCase, EditCareChargeElementUseCase>();
            services.AddScoped<IGetAllAmountOptionUseCase, GetAllAmountOptionUseCase>();
            services.AddScoped<IGetAllPackageStatusUseCase, GetAllPackageStatusUseCase>();
            services.AddScoped<IGetAllPackageUseCase, GetAllPackageUseCase>();
            services.AddScoped<IGetAllPrimarySupportReasonsUseCase, GetAllPrimarySupportReasonsUseCase>();
            services.AddScoped<IGetAllReclaimCategoryUseCase, GetAllReclaimCategoryUseCase>();
            services.AddScoped<IGetAllReclaimFromUseCase, GetAllReclaimFromUseCase>();
            services.AddScoped<IGetAllStatusUseCase, GetAllStatusUseCase>();
            services.AddScoped<IGetAllSupplierUseCase, GetAllSupplierUseCase>();
            services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
            services.AddScoped<IGetApprovedPackagesUseCase, GetApprovedPackagesUseCase>();
            services.AddScoped<IGetBrokeredPackagesUseCase, GetBrokeredPackagesUseCase>();
            services.AddScoped<IGetCarePackageReclaimUseCase, GetCarePackageReclaimUseCase>();
            services.AddScoped<IGetFundedNursingCareCollectorsUseCase, GetFundedNursingCareCollectorsUseCase>();
            services.AddScoped<IGetOpportunityLengthOptionsListUseCase, GetOpportunityLengthOptionsListUseCase>();
            services.AddScoped<IGetOpportunityTimesPerMonthOptionsListUseCase, GetOpportunityTimesPerMonthOptionsListUseCase>();
            services.AddScoped<IGetPackageUseCase, GetPackageUseCase>();
            services.AddScoped<IGetStatusUseCase, GetStatusUseCase>();
            services.AddScoped<IGetSubmittedPackageRequestsUseCase, GetSubmittedPackageRequestsUseCase>();
            services.AddScoped<IGetSupplierBillUseCase, GetSupplierBillUseCase>();
            services.AddScoped<IGetSupplierCostUseCase, GetSupplierCostUseCase>();
            services.AddScoped<IGetTermTimeConsiderationOptionsListUseCase, GetTermTimeConsiderationOptionsListUseCase>();
            services.AddScoped<IPayRunUseCase, PayRunUseCase>();
            services.AddScoped<IResetPackagePaidUpToDateUseCase, ResetPackagePaidUpToDateUseCase>();
            services.AddScoped<IUpdateCarePackageReclaimUseCase, UpdateCarePackageReclaimUseCase>();
            services.AddScoped<IUpsertPackageUseCase, UpsertPackageUseCase>();
            services.AddScoped<IUpsertStatusUseCase, UpsertStatusUseCase>();
            services.AddScoped<IChangeDayCarePackageStatusUseCase, ChangeDayCarePackageStatusUseCase>();
            services.AddScoped<ICreateDayCareCollegeUseCase, CreateDayCareCollegeUseCase>();
            services.AddScoped<ICreateDayCarePackageHistoryUseCase, CreateDayCarePackageHistoryUseCase>();
            services.AddScoped<ICreateDayCarePackageOpportunityUseCase, CreateDayCarePackageOpportunityUseCase>();
            services.AddScoped<ICreateDayCarePackageReclaimUseCase, CreateDayCarePackageReclaimUseCase>();
            services.AddScoped<ICreateDayCarePackageUseCase, CreateDayCarePackageUseCase>();
            services.AddScoped<ICreateDayCareRequestMoreInformationUseCase, CreateDayCareRequestMoreInformationUseCase>();
            services.AddScoped<IDayCarePackageBrokerageUseCase, DayCarePackageBrokerageUseCase>();
            services.AddScoped<IGetDayCareCollegeListUseCase, GetDayCareCollegeListUseCase>();
            services.AddScoped<IGetDayCareCollegeUseCase, GetDayCareCollegeUseCase>();
            services.AddScoped<IGetDayCarePackageForApprovalDetailsUseCase, GetDayCarePackageForApprovalDetailsUseCase>();
            services.AddScoped<IGetDayCarePackageListUseCase, GetDayCarePackageListUseCase>();
            services.AddScoped<IGetDayCarePackageOpportunityListUseCase, GetDayCarePackageOpportunityListUseCase>();
            services.AddScoped<IGetDayCarePackageOpportunityUseCase, GetDayCarePackageOpportunityUseCase>();
            services.AddScoped<IGetDayCarePackageUseCase, GetDayCarePackageUseCase>();
            services.AddScoped<IUpdateDayCarePackageOpportunityUseCase, UpdateDayCarePackageOpportunityUseCase>();
            services.AddScoped<IUpdateDayCarePackageUseCase, UpdateDayCarePackageUseCase>();
            services.AddScoped<IChangeStatusHomeCarePackageUseCase, ChangeStatusHomeCarePackageUseCase>();
            services.AddScoped<ICreateHomeCareBrokerageUseCase, CreateHomeCareBrokerageUseCase>();
            services.AddScoped<ICreateHomeCarePackageReclaimUseCase, CreateHomeCarePackageReclaimUseCase>();
            services.AddScoped<ICreateHomeCareRequestMoreInformationUseCase, CreateHomeCareRequestMoreInformationUseCase>();
            services.AddScoped<IDeleteServiceUseCase, DeleteServiceUseCase>();
            services.AddScoped<IDeleteTimeSlotShiftsUseCase, DeleteTimeSlotShiftsUseCase>();
            services.AddScoped<IGetAllHomeCareApprovalHistoryUseCase, GetAllHomeCareApprovalHistoryUseCase>();
            services.AddScoped<IGetAllHomeCarePackageUseCase, GetAllHomeCarePackageUseCase>();
            services.AddScoped<IGetAllHomeCareServiceTypesUseCase, GetAllHomeCareServiceTypesUseCase>();
            services.AddScoped<IGetAllHomeCareStageUseCase, GetAllHomeCareStageUseCase>();
            services.AddScoped<IGetAllTimeSlotShiftsUseCase, GetAllTimeSlotShiftsUseCase>();
            services.AddScoped<IGetHomeCareApproveBrokeredUseCase, GetHomeCareApproveBrokeredUseCase>();
            services.AddScoped<IGetHomeCareApprovePackageUseCase, GetHomeCareApprovePackageUseCase>();
            services.AddScoped<IGetHomeCareBrokerageUseCase, GetHomeCareBrokerageUseCase>();
            services.AddScoped<IGetServiceUseCase, GetServiceUseCase>();
            services.AddScoped<IGetTimeSlotShiftsUseCase, GetTimeSlotShiftsUseCase>();
            services.AddScoped<IUpsertHomeCarePackageSlotsUseCase, UpsertHomeCarePackageSlotsUseCase>();
            services.AddScoped<IUpsertHomeCarePackageUseCase, UpsertHomeCarePackageUseCase>();
            services.AddScoped<IUpsertServiceUseCase, UpsertServiceUseCase>();
            services.AddScoped<IUpsertTimeSlotShiftsUseCase, UpsertTimeSlotShiftsUseCase>();
            services.AddScoped<IChangeStatusNursingCarePackageUseCase, ChangeStatusNursingCarePackageUseCase>();
            services.AddScoped<ICreateNursingCareBrokerageUseCase, CreateNursingCareBrokerageUseCase>();
            services.AddScoped<ICreateNursingCarePackageReclaimUseCase, CreateNursingCarePackageReclaimUseCase>();
            services.AddScoped<ICreateNursingCarePackageUseCase, CreateNursingCarePackageUseCase>();
            services.AddScoped<ICreateNursingCareRequestMoreInformationUseCase, CreateNursingCareRequestMoreInformationUseCase>();
            services.AddScoped<IDeleteNursingCareAdditionalNeedsUseCase, DeleteNursingCareAdditionalNeedsUseCase>();
            services.AddScoped<IGetAllNursingCareApprovalHistoryUseCase, GetAllNursingCareApprovalHistoryUseCase>();
            services.AddScoped<IGetAllNursingCareHomeTypeUseCase, GetAllNursingCareHomeTypeUseCase>();
            services.AddScoped<IGetAllNursingCarePackageUseCase, GetAllNursingCarePackageUseCase>();
            services.AddScoped<IGetAllNursingCareTypeOfStayOptionUseCase, GetAllNursingCareTypeOfStayOptionUseCase>();
            services.AddScoped<IGetFundedNursingCarePriceUseCase, GetFundedNursingCarePriceUseCase>();
            services.AddScoped<IGetNursingCareAdditionalNeedsPaymentTypesUseCase, GetNursingCareAdditionalNeedsPaymentTypesUseCase>();
            services.AddScoped<IGetNursingCareAdditionalNeedsUseCase, GetNursingCareAdditionalNeedsUseCase>();
            services.AddScoped<IGetNursingCareApproveCommercialUseCase, GetNursingCareApproveCommercialUseCase>();
            services.AddScoped<IGetNursingCareApprovePackageUseCase, GetNursingCareApprovePackageUseCase>();
            services.AddScoped<IGetNursingCareBrokerageUseCase, GetNursingCareBrokerageUseCase>();
            services.AddScoped<IGetNursingCareInvoiceDetailUseCase, GetNursingCareInvoiceDetailUseCase>();
            services.AddScoped<IGetNursingCarePackageUseCase, GetNursingCarePackageUseCase>();
            services.AddScoped<ISetStageToNursingCarePackageUseCase, SetStageToNursingCarePackageUseCase>();
            services.AddScoped<IUpdateNursingCarePackageUseCase, UpdateNursingCarePackageUseCase>();
            services.AddScoped<IUpsertFundedNursingCareUseCase, UpsertFundedNursingCareUseCase>();
            services.AddScoped<IUpsertNursingCareAdditionalNeedsUseCase, UpsertNursingCareAdditionalNeedsUseCase>();
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
