using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Security.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Security
{
    [GenerateMappingFor(typeof(AppUserResponse))]
    [GenerateListMappingFor(typeof(AppUserResponse))]
    public class AppUserDomain
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
