using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LBH.AdultSocialCare.Data.Entities.Common
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
