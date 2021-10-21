using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
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
        public bool IsS117Client { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
