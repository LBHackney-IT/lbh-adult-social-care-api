using LBH.AdultSocialCare.Api.Tests.V1.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class MockAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public MockAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Test user"),
                new Claim(ClaimTypes.Role, RolesEnum.Broker.GetDisplayName()),
                new Claim(ClaimTypes.Role, RolesEnum.BrokerageApprover.GetDisplayName()),
                new Claim(ClaimTypes.Role, RolesEnum.CareChargeManager.GetDisplayName()),
                new Claim(ClaimTypes.Role, RolesEnum.Finance.GetDisplayName()),
                new Claim(ClaimTypes.Role, RolesEnum.FinanceApprover.GetDisplayName())
            };
            var identity = new ClaimsIdentity(claims, "Test");
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, "Test");

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, UserConstants.DefaultApiUserId));

            var result = AuthenticateResult.Success(ticket);

            return Task.FromResult(result);
        }
    }
}
