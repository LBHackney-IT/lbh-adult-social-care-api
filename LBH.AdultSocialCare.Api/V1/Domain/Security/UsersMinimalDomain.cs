using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Domain.Security
{
    [GenerateMappingFor(typeof(User))]
    public class UsersMinimalDomain
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
