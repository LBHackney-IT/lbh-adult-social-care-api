using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCareCollegeGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageOpportunityGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApproveBrokeredGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareStageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.OpportunityLengthOptionGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.OpportunityTimesPerMonthOptionGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApproveBrokeredGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCarePackageReclaimGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierCostGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.TermTimeConsiderationOptionGateways;
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
        }
    }
}
