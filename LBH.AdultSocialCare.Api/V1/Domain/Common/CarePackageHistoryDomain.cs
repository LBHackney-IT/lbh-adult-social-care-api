using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CarePackageHistoryDomain
    {
        public DateTimeOffset DateCreated { get; set; }
        public string Description { get; set; }
        public string RequestMoreInformation { get; set; }
        public string UserRole { get; set; }
    }
}
