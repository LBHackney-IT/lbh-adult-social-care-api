using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackageReclaim))]
    public class CarePackageReclaimCreationDomain
    {
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

        public string AssessmentFileUrl { get; set; }
    }
}
