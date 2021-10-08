using Microsoft.Extensions.DependencyInjection;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class GatewayExtensions
    {
        public static void RegisterGateways(this IServiceCollection services)
        {
            services.AddScoped<IApprovalHistoryGateway, ApprovalHistoryGateway>();
            services.AddScoped<IApprovedPackagesGateway, ApprovedPackagesGateway>();
            services.AddScoped<IBrokeredPackagesGateway, BrokeredPackagesGateway>();
            services.AddScoped<ICareChargeElementTypeGateway, CareChargeElementTypeGateway>();
            services.AddScoped<ICareChargesGateway, CareChargesGateway>();
            services.AddScoped<ICarePackageGateway, CarePackageGateway>();
            services.AddScoped<ICarePackageHistoryGateway, CarePackageHistoryGateway>();
            services.AddScoped<ICarePackageReclaimGateway, CarePackageReclaimGateway>();
            services.AddScoped<ICarePackageSettingsGateway, CarePackageSettingsGateway>();
            services.AddScoped<IClientsGateway, ClientsGateway>();
            services.AddScoped<IInvoiceCreditNoteGateway, InvoiceCreditNoteGateway>();
            services.AddScoped<IOpportunityLengthOptionGateway, OpportunityLengthOptionGateway>();
            services.AddScoped<IOpportunityTimesPerMonthOptionGateway, OpportunityTimesPerMonthOptionGateway>();
            services.AddScoped<IPackageCareChargeGateway, PackageCareChargeGateway>();
            services.AddScoped<IPackageCostClaimersGateway, PackageCostClaimersGateway>();
            services.AddScoped<IPackageGateway, PackageGateway>();
            services.AddScoped<IPrimarySupportReasonGateway, PrimarySupportReasonGateway>();
            services.AddScoped<IServiceUserGateway, ServiceUserGateway>();
            services.AddScoped<IStatusGateway, StatusGateway>();
            services.AddScoped<ISubmittedPackageRequestsGateway, SubmittedPackageRequestsGateway>();
            services.AddScoped<ISupplierCostGateway, SupplierCostGateway>();
            services.AddScoped<ISupplierGateway, SupplierGateway>();
            services.AddScoped<ITermTimeConsiderationOptionGateway, TermTimeConsiderationOptionGateway>();
            services.AddScoped<ITimeSlotShiftsGateway, TimeSlotShiftsGateway>();
            services.AddScoped<IHomeCareApprovalHistoryGateway, HomeCareApprovalHistoryGateway>();
            services.AddScoped<IHomeCareApproveBrokeredGateway, HomeCareApproveBrokeredGateway>();
            services.AddScoped<IHomeCareApprovePackageGateway, HomeCareApprovePackageGateway>();
            services.AddScoped<IHomeCareBrokerageGateway, HomeCareBrokerageGateway>();
            services.AddScoped<IHomeCarePackageGateway, HomeCarePackageGateway>();
            services.AddScoped<IHomeCarePackageReclaimGateway, HomeCarePackageReclaimGateway>();
            services.AddScoped<IHomeCarePackageSlotsGateway, HomeCarePackageSlotsGateway>();
            services.AddScoped<IHomeCareRequestMoreInformationGateway, HomeCareRequestMoreInformationGateway>();
            services.AddScoped<IHomeCareServiceTypeGateway, HomeCareServiceTypeGateway>();
            services.AddScoped<IHomeCareStageGateway, HomeCareStageGateway>();
            services.AddScoped<IFundedNursingCareGateway, FundedNursingCareGateway>();
            services.AddScoped<INursingCareAdditionalNeedsGateway, NursingCareAdditionalNeedsGateway>();
            services.AddScoped<INursingCareApprovalHistoryGateway, NursingCareApprovalHistoryGateway>();
            services.AddScoped<INursingCareApproveCommercialGateway, NursingCareApproveCommercialGateway>();
            services.AddScoped<INursingCareApprovePackageGateway, NursingCareApprovePackageGateway>();
            services.AddScoped<INursingCareBrokerageGateway, NursingCareBrokerageGateway>();
            services.AddScoped<INursingCarePackageGateway, NursingCarePackageGateway>();
            services.AddScoped<INursingCarePackageReclaimGateway, NursingCarePackageReclaimGateway>();
            services.AddScoped<INursingCareRequestMoreInformationGateway, NursingCareRequestMoreInformationGateway>();
            services.AddScoped<IResidentialCareAdditionalNeedsGateway, ResidentialCareAdditionalNeedsGateway>();
            services.AddScoped<IResidentialCareApprovalHistoryGateway, ResidentialCareApprovalHistoryGateway>();
            services.AddScoped<IResidentialCareApproveBrokeredGateway, ResidentialCareApproveBrokeredGateway>();
            services.AddScoped<IResidentialCareApprovePackageGateway, ResidentialCareApprovePackageGateway>();
            services.AddScoped<IResidentialCareBrokerageGateway, ResidentialCareBrokerageGateway>();
            services.AddScoped<IResidentialCarePackageGateway, ResidentialCarePackageGateway>();
            services.AddScoped<IResidentialCarePackageReclaimGateway, ResidentialCarePackageReclaimGateway>();
            services.AddScoped<IResidentialCareRequestMoreInformationGateway, ResidentialCareRequestMoreInformationGateway>();
            services.AddScoped<IRolesGateway, RolesGateway>();
            services.AddScoped<IUsersGateway, UsersGateway>();
        }
    }
}
