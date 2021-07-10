using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Extensions
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params RolesEnum[] allowedRoles)
        {
            // var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(RolesEnum), x));
            var allowedRolesAsStrings = allowedRoles.Select(x => x.GetDisplayName());
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
