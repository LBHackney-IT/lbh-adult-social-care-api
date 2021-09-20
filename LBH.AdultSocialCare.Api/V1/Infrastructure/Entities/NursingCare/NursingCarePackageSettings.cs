using System;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class NursingCarePackageSettings : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public int PackageTypeId { get; set; }

        public bool IsRespiteCare { get; set; }

        public bool IsDischarge { get; set; }

        public bool IsImmediate { get; set; }

        public bool IsReEnablement { get; set; }

        public bool IsS117Client { get; set; }

        public bool HasFnc { get; set; }                // TODO: VK: looks like calculated field

        public CarePackage Package { get; set; }
    }
}
