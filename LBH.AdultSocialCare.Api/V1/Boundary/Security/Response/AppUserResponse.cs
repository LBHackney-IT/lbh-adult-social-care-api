using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Security.Response
{
    public class AppUserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
