using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Data.Entities.CarePackages
{
    public class CarePackageHistory : BaseEntity
    {
        private HistoryStatus _historyStatus;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid CarePackageId { get; set; }

        public string Description { get; set; }
        public string RequestMoreInformation { get; set; }

        public HistoryStatus Status
        {
            get => _historyStatus;
            set => _historyStatus = (int) value == 0 ? HistoryStatus.PackageInformation : value;
        }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage CarePackage { get; set; }
    }
}
