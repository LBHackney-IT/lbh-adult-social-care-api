using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Helpers;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Entities.Interfaces;

namespace LBH.AdultSocialCare.Data.Entities.CarePackages
{
    public class CarePackageReclaim : BaseVersionedEntity, IPackageItem
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
            get => _status;
            set => _status = value != 0 ? CalculateStatus(value) : CalculateStatus();
        }

        public ReclaimType Type { get; set; }
        public ReclaimSubType? SubType { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string ClaimReason { get; set; }

        public Guid? AssessmentFileId { get; set; }
        public string AssessmentFileName { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }

        private ReclaimStatus CalculateStatus(ReclaimStatus value)
        {
            if (value is ReclaimStatus.Cancelled || value is ReclaimStatus.Ended)
            {
                return value;
            }

            if (EndDate != null && DateTimeOffset.Now.Date >= EndDate.Value.Date)
            {
                return ReclaimStatus.Ended;
            }

            return CurrentDateProvider.Now.Date >= StartDate.Date
                ? ReclaimStatus.Active // Ended status should be set manually, so no check for the end date here
                : ReclaimStatus.Pending;
        }

        private ReclaimStatus CalculateStatus()
        {
            if (EndDate != null && CurrentDateProvider.Now.Date >= EndDate.Value.Date)
            {
                return ReclaimStatus.Ended;
            }

            return CurrentDateProvider.Now.Date >= StartDate.Date
                ? ReclaimStatus.Active
                : ReclaimStatus.Pending;
        }

        internal ICurrentDateProvider CurrentDateProvider { get; set; } = new CurrentDateProvider();

        internal override IList<string> VersionedFields { get; } = new List<string>
        {
            nameof(Cost), nameof(StartDate), nameof(EndDate), nameof(ClaimCollector), nameof(Status)
        };
    }
}
