using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain
{
    public class UsersMinimalDomain
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
