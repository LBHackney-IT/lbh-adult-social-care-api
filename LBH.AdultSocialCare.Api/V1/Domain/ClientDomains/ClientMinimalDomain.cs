using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ClientDomains
{
    public class ClientMinimalDomain
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
    }
}