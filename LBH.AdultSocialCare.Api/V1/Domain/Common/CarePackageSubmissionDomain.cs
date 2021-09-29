using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CarePackageSubmissionDomain
    {
        public Guid ApproverId { get; set; }

        public string Notes { get; set; }
    }
}
