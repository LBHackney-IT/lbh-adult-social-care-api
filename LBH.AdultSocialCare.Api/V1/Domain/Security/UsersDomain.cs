using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Security
{
    public class UsersDomain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
