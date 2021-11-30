using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageReclaim))]
    [GenerateMappingFor(typeof(CarePackageReclaimResponse))]
    [GenerateListMappingFor(typeof(CarePackageReclaim))]
    [GenerateListMappingFor(typeof(CarePackageReclaimResponse))]
    public class CarePackageReclaimDomain
    {
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public decimal Cost { get; set; }

        public ClaimCollector ClaimCollector { get; set; }

        public int SupplierId { get; set; }

        public ReclaimStatus Status { get; set; }

        public ReclaimType Type { get; set; }

        public ReclaimSubType SubType { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }

        public string ClaimReason { get; set; }

        public Guid AssessmentFileId { get; set; }
        public string AssessmentFileName { get; set; }
        public bool HasAssessmentBeenCarried { get; set; } = true;
    }
}
