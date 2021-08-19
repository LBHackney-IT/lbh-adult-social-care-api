using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Security.Response
{
    public class TokenResponse
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Groups { get; set; }
    }
}
