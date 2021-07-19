using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.UserDomains
{
    public class HackneyTokenDomain
    {
        public string Sub { get; set; }
        public string Email { get; set; }
        public string Iss { get; set; }
        public string Name { get; set; }
        public List<string> Groups { get; set; }
        public int Iat { get; set; }
    }
}
