using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
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
