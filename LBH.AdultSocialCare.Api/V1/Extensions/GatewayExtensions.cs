using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class GatewayExtensions
    {
        public static void RegisterGateways(this IServiceCollection services)
        {
            services.AddScoped<IPackageGateway, PackageGateway>();
            services.AddScoped<IHomeCareServiceTypeGateway, HomeCareServiceTypeGateway>();
            services.AddScoped<IRolesGateway, RoleGateway>();
            services.AddScoped<ITimeSlotShiftsGateway, TimeSlotShiftsGateway>();
            services.AddScoped<IHomeCarePackageGateway, HomeCarePackageGateway>();
            services.AddScoped<IDayCarePackageGateway, DayCarePackageGateway>();
            services.AddScoped<IDayCareBrokerageInfoGateway, DayCareBrokerageInfoGateway>();
            services.AddScoped<IDayCarePackageOpportunityGateway, DayCarePackageOpportunityGateway>();
            services.AddScoped<IClientsGateway, ClientsGateway>();
            services.AddScoped<IHomeCarePackageSlotsGateway, HomeCarePackageSlotsGateway>();
            services.AddScoped<IUsersGateway, UsersGateway>();
            services.AddScoped<IStatusGateway, StatusGateway>();
            services.AddScoped<IResidentialCarePackageGateway, ResidentialCarePackageGateway>();
            services.AddScoped<INursingCarePackageGateway, NursingCarePackageGateway>();
            services.AddScoped<INursingCareAdditionalNeedsGateway, NursingCareAdditionalNeedsGateway>();
            services.AddScoped<IResidentialCareAdditionalNeedsGateway, ResidentialCareAdditionalNeedsGateway>();
            services.AddScoped<ITermTimeConsiderationOptionGateway, TermTimeConsiderationOptionGateway>();
            services.AddScoped<IOpportunityLengthOptionGateway, OpportunityLengthOptionGateway>();
            services.AddScoped<IOpportunityTimesPerMonthOptionGateway, OpportunityTimesPerMonthOptionGateway>();
            services.AddScoped<IHomeCareBrokerageGateway, HomeCareBrokerageGateway>();
            services.AddScoped<ISupplierGateway, SupplierGateway>();
            services.AddScoped<ISupplierCostGateway, SupplierCostGateway>();
            services.AddScoped<IHomeCareStageGateway, HomeCareStageGateway>();
            services.AddScoped<IApprovalHistoryGateway, ApprovalHistoryGateway>();
            services.AddScoped<IHomeCareApprovePackageGateway, HomeCareApprovePackageGateway>();
            services.AddScoped<IHomeCareApproveBrokeredGateway, HomeCareApproveBrokeredGateway>();
            services.AddScoped<INursingCareApprovalHistoryGateway, NursingCareApprovalHistoryGateway>();
            services.AddScoped<INursingCareApprovePackageGateway, NursingCareApprovePackageGateway>();
            services.AddScoped<INursingCareApproveCommercialGateway, NursingCareApproveCommercialGateway>();
            services.AddScoped<IResidentialCareApprovalHistoryGateway, ResidentialCareApprovalHistoryGateway>();
            services.AddScoped<IResidentialCareApprovePackageGateway, ResidentialCareApprovePackageGateway>();
            services.AddScoped<IResidentialCareApproveBrokeredGateway, ResidentialCareApproveBrokeredGateway>();
            services.AddScoped<IHomeCareRequestMoreInformationGateway, HomeCareRequestMoreInformationGateway>();
            services.AddScoped<IDayCareCollegeGateway, DayCareCollegeGateway>();
            services.AddScoped<IDayCareRequestMoreInformationGateway, DayCareRequestMoreInformationGateway>();
            services.AddScoped<INursingCareRequestMoreInformationGateway, NursingCareRequestMoreInformationGateway>();
            services.AddScoped<IResidentialCareRequestMoreInformationGateway, ResidentialCareRequestMoreInformationGateway>();
            services.AddScoped<IHomeCarePackageReclaimGateway, HomeCarePackageReclaimGateway>();
            services.AddScoped<IDayCarePackageReclaimGateway, DayCarePackageReclaimGateway>();
            services.AddScoped<INursingCarePackageReclaimGateway, NursingCarePackageReclaimGateway>();
            services.AddScoped<IResidentialCarePackageReclaimGateway, ResidentialCarePackageReclaimGateway>();
            services.AddScoped<ISupplierBillGateway, SupplierBillGateway>();
            services.AddScoped<IPrimarySupportReasonGateway, PrimarySupportReasonGateway>();
            services.AddScoped<INursingCareBrokerageGateway, NursingCareBrokerageGateway>();
            services.AddScoped<IResidentialCareBrokerageGateway, ResidentialCareBrokerageGateway>();
            services.AddScoped<ISubmittedPackageRequestsGateway, SubmittedPackageRequestsGateway>();
            services.AddScoped<IApprovedPackagesGateway, ApprovedPackagesGateway>();
            services.AddScoped<IBrokeredPackagesGateway, BrokeredPackagesGateway>();
            services.AddScoped<IPackageCostClaimersGateway, PackageCostClaimersGateway>();
            services.AddScoped<IFundedNursingCaseGateway, FundedNursingCareGateway>();
            services.AddScoped<ICareChargesGateway, CareChargesGateway>();
            services.AddScoped<IPackageCareChargeGateway, PackageCareChargeGateway>();
        }
    }
}
