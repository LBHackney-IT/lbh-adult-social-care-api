using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CareChargePackagesDomain
    {
        public string Status { get; set; }
        public string ServiceUser { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int HackneyId { get; set; }
        public string PackageType { get; set; }
        public Guid PackageId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
