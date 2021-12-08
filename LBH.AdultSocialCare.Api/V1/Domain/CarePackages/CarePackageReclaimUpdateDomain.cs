using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageReclaim))]
    [GenerateListMappingFor(typeof(CarePackageReclaim))]
    public class CarePackageReclaimUpdateDomain
    {
        public Guid Id { get; set; }

        public decimal Cost { get; set; }

        public ClaimCollector ClaimCollector { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string ClaimReason { get; set; }

        public Guid? AssessmentFileId { get; set; }
        public IFormFile AssessmentFile { get; set; }
        public bool HasAssessmentBeenCarried { get; set; }
    }
}
