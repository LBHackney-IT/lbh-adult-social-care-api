using System;
using Microsoft.AspNetCore.Identity;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
    }
}
