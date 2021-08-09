using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ClientBoundary
{
    public class ClientMinimalResponse
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
    }
}
