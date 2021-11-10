using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            UserRoles = new List<AppUserRole>();
        }

        public string Name { get; set; }
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}
