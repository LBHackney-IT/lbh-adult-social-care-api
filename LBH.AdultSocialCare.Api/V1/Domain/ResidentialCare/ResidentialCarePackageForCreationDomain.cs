using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    [GenerateMappingFor(typeof(CarePackage))]
    [GenerateMappingFor(typeof(ResidentialCarePackageSettings))]
    public class ResidentialCarePackageForCreationDomain
    {
        // Core package
        public Guid ServiceUserId { get; set; }
        public string PrimarySupportReason { get; set; }
        public string PackagingScheduling { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        // Package settings
        public bool HasRespiteCare { get; set; }

        public bool HasDischargePackage { get; set; }
        public bool IsImmediate { get; set; }
        public bool IsReEnablement { get; set; }
        public bool IsS117Client { get; set; }
    }
}
