using System;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class CarePackageReclaimResponse
    {
        public Guid Id { get; set; }
        public Guid CarePackageId { get; set; }

        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        public ClaimCollector ClaimCollector { get; set; }

        public ReclaimStatus Status { get; set; }
        public ReclaimType Type { get; set; }
        public ReclaimSubType SubType { get; set; }

        public string SubTypeName => SubType.GetDisplayName();

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string ClaimReason { get; set; }

        public Guid AssessmentFileId { get; set; }
        public string AssessmentFileName { get; set; }
        public bool HasAssessmentBeenCarried { get; set; }
    }
}
