using HttpServices.Services.Concrete;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.AuthUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.AuthUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.BrokeredPackagesUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.BrokeredPackagesUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageReclaimUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareRequestMoreInformationUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovalHistoryUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovalHistoryUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareBrokerageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCarePackageReclaimUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityTimesPerMonthOptionUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityTimesPerMonthOptionUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.PackageStatusUseCases;
using LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases;
using LBH.AdultSocialCare.Api.V1.UseCase.PrimarySupportReasonUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.PrimarySupportReasonUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareApprovalHistoryUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareApprovalHistoryUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareBrokerageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCarePackageReclaimUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCarePackageReclaimUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareRequestMoreInformationUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases;
using LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.SubmittedPackageRequestsUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierBillUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierBillUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.TermTimeConsiderationOptionUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.TermTimeConsiderationOptionUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.TransactionsUseCases.PayRunUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.UserUseCases;
using Microsoft.Extensions.DependencyInjection;
using ICreateResidentialCarePackageUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.ICreateResidentialCarePackageUseCase;
using IDeleteResidentialCareAdditionalNeedsUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.IDeleteResidentialCareAdditionalNeedsUseCase;
using IGetAllResidentialCareHomeTypeUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.IGetAllResidentialCareHomeTypeUseCase;
using IGetAllResidentialCarePackageUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.IGetAllResidentialCarePackageUseCase;
using IGetAllResidentialCareTypeOfStayOptionUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.IGetAllResidentialCareTypeOfStayOptionUseCase;
using IGetResidentialCareAdditionalNeedsUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.IGetResidentialCareAdditionalNeedsUseCase;
using IGetResidentialCarePackageUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.IGetResidentialCarePackageUseCase;
using IUpdateResidentialCarePackageUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.IUpdateResidentialCarePackageUseCase;
using IUpsertResidentialCareAdditionalNeedsUseCase = LBH.AdultSocialCare.Api.V1.UseCase.Interfaces.IUpsertResidentialCareAdditionalNeedsUseCase;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class UseCaseExtensions
    {
        public static void RegisterUseCases(this IServiceCollection services)
        {
            #region Package

            services.AddScoped<IUpsertPackageUseCase, UpsertPackageUseCase>();
            services.AddScoped<IGetPackageUseCase, GetPackageUseCase>();
            services.AddScoped<IGetAllPackageUseCase, GetAllPackageUseCase>();
            services.AddScoped<IDeletePackageUseCase, DeletePackageUseCase>();

            #endregion Package

            #region Service

            services.AddScoped<IUpsertServiceUseCase, UpsertServiceUseCase>();
            services.AddScoped<IGetServiceUseCase, GetServiceUseCase>();
            services.AddScoped<IGetAllHomeCareServiceTypesUseCase, GetAllHomeCareServiceTypesUseCase>();
            services.AddScoped<IDeleteServiceUseCase, DeleteServiceUseCase>();

            #endregion Service

            #region Role

            services.AddScoped<IUpsertRoleUseCase, UpsertRoleUseCase>();
            services.AddScoped<IGetRoleUseCase, GetRoleUseCase>();
            services.AddScoped<IGetAllRoleUseCase, GetAllRoleUseCase>();
            services.AddScoped<IDeleteRoleUseCase, DeleteRoleUseCase>();

            #endregion Role

            #region HomeCarePackage

            services.AddScoped<IUpsertHomeCarePackageUseCase, UpsertHomeCarePackageUseCase>();
            services.AddScoped<IChangeStatusHomeCarePackageUseCase, ChangeStatusHomeCarePackageUseCase>();
            services.AddScoped<IGetAllHomeCarePackageUseCase, GetAllHomeCarePackageUseCase>();

            #endregion HomeCarePackage

            #region DayCarePackage

            services.AddScoped<ICreateDayCarePackageUseCase, CreateDayCarePackageUseCase>();
            services.AddScoped<IGetDayCarePackageUseCase, GetDayCarePackageUseCase>();
            services.AddScoped<IGetDayCarePackageListUseCase, GetDayCarePackageListUseCase>();
            services.AddScoped<IUpdateDayCarePackageUseCase, UpdateDayCarePackageUseCase>();
            services.AddScoped<IGetDayCarePackageForApprovalDetailsUseCase, GetDayCarePackageForApprovalDetailsUseCase>();
            services.AddScoped<ICreateDayCarePackageHistoryUseCase, CreateDayCarePackageHistoryUseCase>();
            services.AddScoped<IChangeDayCarePackageStatusUseCase, ChangeDayCarePackageStatusUseCase>();

            #endregion DayCarePackage

            #region DayCarePackageOpportunity

            services.AddScoped<ICreateDayCarePackageOpportunityUseCase, CreateDayCarePackageOpportunityUseCase>();
            services.AddScoped<IGetDayCarePackageOpportunityListUseCase, GetDayCarePackageOpportunityListUseCase>();
            services.AddScoped<IGetDayCarePackageOpportunityUseCase, GetDayCarePackageOpportunityUseCase>();
            services.AddScoped<IUpdateDayCarePackageOpportunityUseCase, UpdateDayCarePackageOpportunityUseCase>();

            #endregion DayCarePackageOpportunity

            #region HomeCarePackageSlots

            services.AddScoped<IUpsertHomeCarePackageSlotsUseCase, UpsertHomeCarePackageSlotsUseCase>();

            #endregion HomeCarePackageSlots

            #region TimeSlotShift

            services.AddScoped<IUpsertTimeSlotShiftsUseCase, UpsertTimeSlotShiftsUseCase>();
            services.AddScoped<IGetTimeSlotShiftsUseCase, GetTimeSlotShiftsUseCase>();
            services.AddScoped<IGetAllTimeSlotShiftsUseCase, GetAllTimeSlotShiftsUseCase>();
            services.AddScoped<IDeleteTimeSlotShiftsUseCase, DeleteTimeSlotShiftsUseCase>();

            #endregion TimeSlotShift

            #region Client

            services.AddScoped<IUpsertClientsUseCase, UpsertClientsUseCase>();
            services.AddScoped<IGetClientsUseCase, GetClientsUseCase>();
            services.AddScoped<IDeleteClientsUseCase, DeleteClientsUseCase>();

            #endregion Client

            #region User

            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
            services.AddScoped<IDeleteUsersUseCase, DeleteUsersUseCase>();
            services.AddScoped<IAuthUseCase, AuthUseCase>();
            services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();

            #endregion User

            #region PackageStatuses

            services.AddScoped<IUpsertStatusUseCase, UpsertStatusUseCase>();
            services.AddScoped<IGetStatusUseCase, GetStatusUseCase>();
            services.AddScoped<IGetAllStatusUseCase, GetAllStatusUseCase>();
            services.AddScoped<IDeleteStatusUseCase, DeleteStatusUseCase>();

            #endregion PackageStatuses

            #region ResidentialCarePackages

            services.AddScoped<IUpdateResidentialCarePackageUseCase, UpdateResidentialCarePackageUseCase>();
            services.AddScoped<IGetResidentialCarePackageUseCase, GetResidentialCarePackageUseCase>();
            services.AddScoped<IGetResidentialCareAdditionalNeedsUseCase, GetResidentialCareAdditionalNeedsUseCase>();
            services.AddScoped<IUpsertResidentialCareAdditionalNeedsUseCase, UpsertResidentialCareAdditionalNeedsUseCase>();
            services.AddScoped<IChangeStatusResidentialCarePackageUseCase, ChangeStatusResidentialCarePackageUseCase>();
            services.AddScoped<IGetAllResidentialCarePackageUseCase, GetAllResidentialCarePackageUseCase>();
            services.AddScoped<IGetAllResidentialCareHomeTypeUseCase, GetAllResidentialCareHomeTypeUseCase>();
            services.AddScoped<IGetAllResidentialCareTypeOfStayOptionUseCase, GetAllResidentialCareTypeOfStayOptionUseCase>();
            services.AddScoped<ICreateResidentialCarePackageUseCase, CreateResidentialCarePackageUseCase>();
            services.AddScoped<IDeleteResidentialCareAdditionalNeedsUseCase, DeleteResidentialCareAdditionalNeedsUseCase>();

            #endregion ResidentialCarePackages

            #region NursingCarePackages

            services.AddScoped<IUpdateNursingCarePackageUseCase, UpdateNursingCarePackageUseCase>();
            services.AddScoped<IGetNursingCarePackageUseCase, GetNursingCarePackageUseCase>();
            services.AddScoped<IGetNursingCareAdditionalNeedsUseCase, GetNursingCareAdditionalNeedsUseCase>();
            services.AddScoped<IUpsertNursingCareAdditionalNeedsUseCase, UpsertNursingCareAdditionalNeedsUseCase>();
            services.AddScoped<IChangeStatusNursingCarePackageUseCase, ChangeStatusNursingCarePackageUseCase>();
            services.AddScoped<IGetAllNursingCarePackageUseCase, GetAllNursingCarePackageUseCase>();
            services.AddScoped<IGetAllNursingCareHomeTypeUseCase, GetAllNursingCareHomeTypeUseCase>();
            services.AddScoped<IGetAllNursingCareTypeOfStayOptionUseCase, GetAllNursingCareTypeOfStayOptionUseCase>();
            services.AddScoped<ICreateNursingCarePackageUseCase, CreateNursingCarePackageUseCase>();
            services.AddScoped<IDeleteNursingCareAdditionalNeedsUseCase, DeleteNursingCareAdditionalNeedsUseCase>();

            #endregion NursingCarePackages

            #region TermTimeConsiderationOptions

            services.AddScoped<IGetTermTimeConsiderationOptionsListUseCase, GetTermTimeConsiderationOptionsListUseCase>();

            #endregion TermTimeConsiderationOptions

            #region OpportunityLengthOptions

            services.AddScoped<IGetOpportunityLengthOptionsListUseCase, GetOpportunityLengthOptionsListUseCase>();

            #endregion OpportunityLengthOptions

            #region OpportunityTimesPerMonthOptions

            services
                .AddScoped<IGetOpportunityTimesPerMonthOptionsListUseCase, GetOpportunityTimesPerMonthOptionsListUseCase
                >();

            #endregion OpportunityTimesPerMonthOptions

            #region HomeCareBrokerage

            services.AddScoped<IGetAllHomeCareStageUseCase, GetAllHomeCareStageUseCase>();
            services.AddScoped<IGetHomeCareBrokerageUseCase, GetHomeCareBrokerageUseCase>();
            services.AddScoped<ICreateHomeCareBrokerageUseCase, CreateHomeCareBrokerageUseCase>();
            services.AddScoped<ICreateHomeCareRequestMoreInformationUseCase, CreateHomeCareRequestMoreInformationUseCase>();

            #endregion HomeCareBrokerage

            #region Supplier

            services.AddScoped<ICreateSupplierUseCase, CreateSupplierUseCase>();
            services.AddScoped<IGetAllSupplierUseCase, GetAllSupplierUseCase>();
            services.AddScoped<IGetSupplierCostUseCase, GetSupplierCostUseCase>();
            services.AddScoped<ICreateSupplierCostUseCase, CreateSupplierCostUseCase>();

            #endregion Supplier

            #region HomeCareApprovalHistory

            services.AddScoped<IHomeCareApprovalHistoryGateway, HomeCareApprovalHistoryGateway>();
            services.AddScoped<IGetAllHomeCareApprovalHistoryUseCase, GetAllHomeCareApprovalHistoryUseCase>();

            #endregion HomeCareApprovalHistory

            #region HomeCareApprovePackage

            services.AddScoped<IGetHomeCareApprovePackageUseCase, GetHomeCareApprovePackageUseCase>();

            #endregion HomeCareApprovePackage

            #region HomeCareApproveBrokered

            services.AddScoped<IGetHomeCareApproveBrokeredUseCase, GetHomeCareApproveBrokeredUseCase>();

            #endregion HomeCareApproveBrokered

            #region NursingCareApprovalHistory

            services.AddScoped<IGetAllNursingCareApprovalHistoryUseCase, GetAllNursingCareApprovalHistoryUseCase>();

            #endregion NursingCareApprovalHistory

            #region NursingCareApprovePackage

            services.AddScoped<IGetNursingCareApprovePackageUseCase, GetNursingCareApprovePackageUseCase>();

            #endregion NursingCareApprovePackage

            #region NursingCareApproveCommercial

            services.AddScoped<IGetNursingCareApproveCommercialUseCase, GetNursingCareApproveCommercialUseCase>();
            services.AddScoped<IGetNursingCareInvoiceDetailUseCase, GetNursingCareInvoiceDetailUseCase>();

            #endregion NursingCareApproveCommercial

            #region ResidentialCareApprovalHistory

            services.AddScoped<IGetAllResidentialCareApprovalHistoryUseCase, GetAllResidentialCareApprovalHistoryUseCase>();

            #endregion ResidentialCareApprovalHistory

            #region ResidentialCareApprovePackage

            services.AddScoped<IGetResidentialCareApprovePackageUseCase, GetResidentialCareApprovePackageUseCase>();

            #endregion ResidentialCareApprovePackage

            #region ResidentialCareApproveBrokered

            services.AddScoped<IGetResidentialCareApproveBrokeredUseCase, GetResidentialCareApproveBrokeredUseCase>();
            services.AddScoped<IGetResidentialCareInvoiceDetailUseCase, GetResidentialCareInvoiceDetailUseCase>();

            #endregion ResidentialCareApproveBrokered

            #region DayCareCollege

            services.AddScoped<ICreateDayCareCollegeUseCase, CreateDayCareCollegeUseCase>();
            services.AddScoped<IGetDayCareCollegeUseCase, GetDayCareCollegeUseCase>();
            services.AddScoped<IGetDayCareCollegeListUseCase, GetDayCareCollegeListUseCase>();

            #endregion DayCareCollege

            #region DayCareBrokerage

            services.AddScoped<ICreateDayCareRequestMoreInformationUseCase, CreateDayCareRequestMoreInformationUseCase>();
            services.AddScoped<IDayCarePackageBrokerageUseCase, DayCarePackageBrokerageUseCase>();

            #endregion DayCareBrokerage

            #region NursingCareBrokerage

            services.AddScoped<ICreateNursingCareRequestMoreInformationUseCase, CreateNursingCareRequestMoreInformationUseCase>();
            services.AddScoped<IGetNursingCareBrokerageUseCase, GetNursingCareBrokerageUseCase>();
            services.AddScoped<ICreateNursingCareBrokerageUseCase, CreateNursingCareBrokerageUseCase>();
            services.AddScoped<ISetStageToNursingCarePackageUseCase, SetStageToNursingCarePackageUseCase>();

            #endregion NursingCareBrokerage

            #region ResidentialCareBrokerage

            services.AddScoped<ICreateResidentialCareRequestMoreInformationUseCase, CreateResidentialCareRequestMoreInformationUseCase>();
            services.AddScoped<IGetResidentialCareBrokerageUseCase, GetResidentialCareBrokerageUseCase>();
            services.AddScoped<ICreateResidentialCareBrokerageUseCase, CreateResidentialCareBrokerageUseCase>();
            services.AddScoped<ISetStageToResidentialCarePackageUseCase, SetStageToResidentialCarePackageUseCase>();

            #endregion ResidentialCareBrokerage

            #region PackageReclaim

            services.AddScoped<ICreateHomeCarePackageReclaimUseCase, CreateHomeCarePackageReclaimUseCase>();
            services.AddScoped<IGetAllAmountOptionUseCase, GetAllAmountOptionUseCase>();
            services.AddScoped<IGetAllReclaimCategoryUseCase, GetAllReclaimCategoryUseCase>();
            services.AddScoped<IGetAllReclaimFromUseCase, GetAllReclaimFromUseCase>();
            services.AddScoped<ICreateDayCarePackageReclaimUseCase, CreateDayCarePackageReclaimUseCase>();
            services.AddScoped<ICreateNursingCarePackageReclaimUseCase, CreateNursingCarePackageReclaimUseCase>();
            services.AddScoped<ICreateResidentialCarePackageReclaimUseCase, CreateResidentialCarePackageReclaimUseCase>();

            #endregion PackageReclaim

            #region TransactionsApi

            services.AddScoped<IPayRunUseCase, PayRunUseCase>();

            #endregion TransactionsApi

            #region SupplierBill

            services.AddScoped<IGetSupplierBillUseCase, GetSupplierBillUseCase>();

            #endregion SupplierBill

            #region SupplierBill

            services.AddScoped<IGetAllPrimarySupportReasonsUseCase, GetAllPrimarySupportReasonsUseCase>();

            #endregion SupplierBill

            #region SubmittedPackageRequests

            services.AddScoped<IGetSubmittedPackageRequestsUseCase, GetSubmittedPackageRequestsUseCase>();
            services.AddScoped<IGetAllPackageStatusUseCase, GetAllPackageStatusUseCase>();

            #endregion

            #region ApprovedPackages

            services.AddScoped<IGetApprovedPackagesUseCase, GetApprovedPackagesUseCase>();

            #endregion

            #region BrokeredPackages

            services.AddScoped<IGetBrokeredPackagesUseCase, GetBrokeredPackagesUseCase>();
            services.AddScoped<IAssignToUserUseCase, AssignToUserUseCase>();

            #endregion

            #region Transaction

            services.AddScoped<ITransactionsService, TransactionsService>();

            #endregion

        }
    }
}
