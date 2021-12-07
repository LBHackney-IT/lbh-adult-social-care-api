using LBH.AdultSocialCare.Data.Constants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CareChargeReclaimCreationDomain
    {
        private ReclaimStatus _status;
        private ReclaimType _type = ReclaimType.CareCharge;
        public Guid? Id { get; set; }
        public Guid CarePackageId { get; set; }
        public decimal Cost { get; set; }
        public ClaimCollector ClaimCollector { get; set; }
        public ReclaimSubType SubType { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string Description { get; set; }
        public string ClaimReason { get; set; }

        public ReclaimType Type
        {
            get => _type;
            set => _type = value != _type ? _type : value;
        }

        public ReclaimStatus Status
        {
            get => _status;
            set => _status = CalculateStatus(value);
        }

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

            return DateTimeOffset.Now.Date >= StartDate.Date
                ? ReclaimStatus.Active
                : ReclaimStatus.Pending;
        }
    }
}
