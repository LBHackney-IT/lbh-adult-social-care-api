using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageHistoryViewResponse))]
    public class CarePackageHistoryViewDomain
    {
        public Guid CarePackageId { get; set; }
        public string PackageType { get; set; }
        public string BrokeredBy { get; set; }
        public DateTimeOffset AssignedOn { get; set; }
        public string ApprovedBy { get; set; }
        public DateTimeOffset ApprovedOn { get; set; }
        public IEnumerable<CarePackageHistoryDomain> History { get; set; }
    }
}
