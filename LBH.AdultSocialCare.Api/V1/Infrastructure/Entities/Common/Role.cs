using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
        {
            UserRoles = new HashSet<AppUserRole>();
        }

        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
