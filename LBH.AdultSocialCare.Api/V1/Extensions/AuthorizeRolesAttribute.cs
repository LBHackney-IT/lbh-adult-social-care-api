using Common.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using LBH.AdultSocialCare.Data.Constants.Enums;

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
