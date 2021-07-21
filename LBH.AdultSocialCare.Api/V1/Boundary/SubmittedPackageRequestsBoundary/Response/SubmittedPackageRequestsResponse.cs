using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.SubmittedPackageRequestsBoundary.Response
{
    public class SubmittedPackageRequestsResponse
    {
        public Guid PackageId { get; set; }
        public Guid ClientId { get; set; }
        public string Client { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string PrimarySupportReason { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Approver { get; set; }
        public int SubmittedDaysAgo { get; set; }
        public string StatusName { get; set; }
    }
}
