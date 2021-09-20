using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare
{
    public class ResidentialCarePackageSettings : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public bool IsRespiteCare { get; set; }

        public bool IsDischarge { get; set; }

        public bool IsImmediate { get; set; }

        public bool IsReEnablement { get; set; }

        public bool IsS117Client { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }
    }
}
