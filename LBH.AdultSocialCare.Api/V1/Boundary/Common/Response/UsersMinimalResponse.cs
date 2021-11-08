using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class UsersMinimalResponse
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
