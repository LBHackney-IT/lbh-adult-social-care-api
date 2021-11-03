using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Security;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    [GenerateMappingFor(typeof(UsersMinimalDomain))]
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
