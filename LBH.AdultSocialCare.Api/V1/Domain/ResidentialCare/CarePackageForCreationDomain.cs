using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    [GenerateMappingFor(typeof(CarePackage))]
    [GenerateMappingFor(typeof(CarePackageSettings))]
    public class CarePackageForCreationDomain
    {
        // Core package
        public Guid ServiceUserId { get; set; }

        public string PrimarySupportReason { get; set; }

        // Package settings
        public bool HasRespiteCare { get; set; }

        public bool HasDischargePackage { get; set; }
        public bool IsImmediate { get; set; }
        public bool IsReEnablement { get; set; }
        public bool IsS117Client { get; set; }
    }
}
