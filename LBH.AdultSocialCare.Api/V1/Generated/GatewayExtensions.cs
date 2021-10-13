using Microsoft.Extensions.DependencyInjection;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Security.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public static class GatewayExtensions
    {
        public static void RegisterGateways(this IServiceCollection services)
        {
            services.AddScoped<IApprovedPackagesGateway, ApprovedPackagesGateway>();
            services.AddScoped<ICareChargesGateway, CareChargesGateway>();
            services.AddScoped<ICarePackageGateway, CarePackageGateway>();
            services.AddScoped<ICarePackageHistoryGateway, CarePackageHistoryGateway>();
            services.AddScoped<ICarePackageReclaimGateway, CarePackageReclaimGateway>();
            services.AddScoped<ICarePackageSettingsGateway, CarePackageSettingsGateway>();
            services.AddScoped<IClientsGateway, ClientsGateway>();
            services.AddScoped<IFundedNursingCareGateway, FundedNursingCareGateway>();
            services.AddScoped<IPrimarySupportReasonGateway, PrimarySupportReasonGateway>();
            services.AddScoped<IServiceUserGateway, ServiceUserGateway>();
            services.AddScoped<IStatusGateway, StatusGateway>();
            services.AddScoped<ISupplierGateway, SupplierGateway>();
            services.AddScoped<IRolesGateway, RolesGateway>();
            services.AddScoped<IUsersGateway, UsersGateway>();
        }
    }
}
