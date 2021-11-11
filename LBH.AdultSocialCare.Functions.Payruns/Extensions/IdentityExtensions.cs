using System.Security.Claims;
using System.Security.Principal;

namespace LBH.AdultSocialCare.Functions.Payruns.Extensions
{
    public static class IdentityExtensions
    {
        private static string Get(this IIdentity identity, string claimType)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst(claimType);
            return claim != null ? claim.Value : string.Empty;
        }

        public static string GetEmailAddress(this IIdentity identity)
        {
            return identity.Get(ClaimTypes.Name);
        }

        public static string GetUserId(this IIdentity identity)
        {
            return identity.Get(ClaimTypes.NameIdentifier);
        }

        public static string GetFullName(this IIdentity identity)
        {
            return identity.Get(ClaimTypes.GivenName);
        }
    }
}
