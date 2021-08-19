using LBH.AdultSocialCare.Api.V1.Boundary;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using Microsoft.Extensions.HealthChecks;

namespace LBH.AdultSocialCare.Api.V1.UseCase
{
    public class DbHealthCheckUseCase
    {
        private readonly IHealthCheckService _healthCheckService;

        public DbHealthCheckUseCase(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        public HealthCheckResponse Execute()
        {
            var result = _healthCheckService.CheckHealthAsync().Result;

            var success = result.CheckStatus == CheckStatus.Healthy;
            return new HealthCheckResponse(success, result.Description);
        }
    }

}
