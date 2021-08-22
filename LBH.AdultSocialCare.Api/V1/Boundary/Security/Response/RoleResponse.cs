using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Security.Response
{
    public class RoleResponse
    {
        public Guid Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
