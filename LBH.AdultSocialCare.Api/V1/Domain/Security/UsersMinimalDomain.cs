using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Security
{
    public class UsersMinimalDomain
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
