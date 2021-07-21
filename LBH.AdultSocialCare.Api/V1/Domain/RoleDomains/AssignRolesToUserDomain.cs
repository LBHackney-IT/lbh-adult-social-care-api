using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.RoleDomains
{
    public class AssignRolesToUserDomain
    {
        public Guid UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
