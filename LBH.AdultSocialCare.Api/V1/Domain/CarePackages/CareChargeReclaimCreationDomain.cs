using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CareChargeReclaimCreationDomain
    {
        public Guid? Id { get; set; }
        public Guid CarePackageId { get; set; }
        public decimal Cost { get; set; }
        public ClaimCollector ClaimCollector { get; set; }
        public ReclaimSubType SubType { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string Description { get; set; }
        public string ClaimReason { get; set; }
    }
}
