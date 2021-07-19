using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.RoleDomains
{
    public class RolesDomain
    {
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
