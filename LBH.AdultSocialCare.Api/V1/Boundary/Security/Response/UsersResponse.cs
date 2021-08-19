using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Security.Response
{
    public class UsersResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
