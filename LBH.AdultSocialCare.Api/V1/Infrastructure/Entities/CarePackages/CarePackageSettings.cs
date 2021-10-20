using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageSettingsDomain))]
    public class CarePackageSettings : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public bool HasRespiteCare { get; set; }

        public bool HasDischargePackage { get; set; }

        public bool HospitalAvoidance { get; set; }

        public bool IsReEnablement { get; set; }

        public bool IsS117Client { get; set; }
        public bool IsS117ClientConfirmed { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }
    }
}
