using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CarePackageSubmissionDomain
    {
        public Guid ApproverId { get; set; }

        public string Notes { get; set; }
    }
}
