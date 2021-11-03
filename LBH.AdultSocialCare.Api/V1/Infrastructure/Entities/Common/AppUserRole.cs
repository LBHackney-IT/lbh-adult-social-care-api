using Microsoft.AspNetCore.Identity;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
