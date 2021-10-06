using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Security.Request
{
    public class UsersWithRolesRequest
    {
        public IEnumerable<string> Roles { get; set; }
    }
}
