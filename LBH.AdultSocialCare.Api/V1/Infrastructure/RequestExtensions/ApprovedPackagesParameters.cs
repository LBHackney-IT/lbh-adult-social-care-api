using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions
{
    public class ApprovedPackagesParameters : RequestParameters
    {
        public int? HackneyId { get; set; }
        public string ClientName { get; set; }
        public int? PackageTypeId { get; set; }
        public Guid? SocialWorkerId { get; set; }
        public Guid? ApproverId { get; set; }
        public decimal? ByValue { get; set; }
    }
}
