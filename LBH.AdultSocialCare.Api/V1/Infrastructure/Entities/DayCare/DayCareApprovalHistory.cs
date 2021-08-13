using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare
{
    public class DayCareApprovalHistory : BaseEntityTmp
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid HistoryId { get; set; }

        [Required] public Guid DayCarePackageId { get; set; }
        [Required] public int PackageStatusId { get; set; }
        [Required] public string LogText { get; set; }
        public string LogSubText { get; set; }
        [Required] public string CreatorRole { get; set; }
        [ForeignKey(nameof(PackageStatusId))] public DayCarePackageStatus PackageStatus { get; set; }
        [ForeignKey((nameof(DayCarePackageId)))] public DayCarePackage DayCarePackage { get; set; }
    }
}
