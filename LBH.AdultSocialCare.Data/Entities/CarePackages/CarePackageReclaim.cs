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
            // Status (unless it's final - cancelled) depends on current time
            // so it's inherently pure calculated. Saving it have no reason
            // 'cause anyway we have to recalculate it each day
            get => CalculateStatus();
            set => _status = value;
        }

        public ReclaimType Type { get; set; }
        public ReclaimSubType? SubType { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string Description { get; set; }
        public string ClaimReason { get; set; }
        public string Subjective { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }

        private ReclaimStatus CalculateStatus()
        {
            if (_status is ReclaimStatus.Cancelled || _status is ReclaimStatus.Ended)
            {
                return _status;
            }

            if (EndDate != null && DateTimeOffset.UtcNow.Date > EndDate.Value.Date)
            {
                return ReclaimStatus.Ended;
            }

            return DateTimeOffset.UtcNow.Date >= StartDate.Date
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
