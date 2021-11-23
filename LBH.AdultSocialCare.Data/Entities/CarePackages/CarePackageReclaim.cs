using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Interfaces;

namespace LBH.AdultSocialCare.Data.Entities.CarePackages
{
    public class CarePackageReclaim : BaseEntity, IPackageItem
    {
        private ReclaimStatus _status;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        public ClaimCollector ClaimCollector { get; set; }

        public ReclaimStatus Status
        {
            get => CalculateStatus();
            set => _status = value;
        }

        public ReclaimType Type { get; set; }
        public ReclaimSubType SubType { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string ClaimReason { get; set; }

        public Guid? AssessmentFileId { get; set; }
        public string AssessmentFileName { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }

        private ReclaimStatus CalculateStatus()
        {
            if (_status is ReclaimStatus.Cancelled || _status is ReclaimStatus.Ended)
            {
                return _status;
            }

            return DateTimeOffset.Now.Date >= StartDate.Date
                ? ReclaimStatus.Active // Ended status should be set manually, so no check for the end date here
                : ReclaimStatus.Pending;
        }
    }
}
