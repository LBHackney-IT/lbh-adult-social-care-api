using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
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
