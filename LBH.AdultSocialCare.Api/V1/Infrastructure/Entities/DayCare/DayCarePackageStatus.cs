using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare
{
    public class DayCarePackageStatus : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageStatusId { get; set; }
        [Required] public string StatusName { get; set; }
        [Required] public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
        public int SequenceNumber { get; set; }  // Order in which the statuses/stages should appear. 1,2,3,4,5. No duplicates
        public bool IsDayCareStatus { get; set; } = true;
        public bool IsStatusActive { get; set; } = true;
        public string Stage { get; set; }
        public string PackageAction { get; set; } // accepted, queried, rejected
        [ForeignKey(nameof(CreatorId))] public User Creator { get; set; }
        [ForeignKey(nameof(UpdaterId))] public User Updater { get; set; }
    }
}
