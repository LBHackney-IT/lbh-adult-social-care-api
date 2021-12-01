using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Data.Entities.CarePackages
{
    public class CarePackageHistory : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid CarePackageId { get; set; }

        public string Description { get; set; }
        public string RequestMoreInformation { get; set; }

        public HistoryStatus Status { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage CarePackage { get; set; }
    }
}
