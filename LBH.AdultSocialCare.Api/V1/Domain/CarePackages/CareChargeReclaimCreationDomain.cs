using LBH.AdultSocialCare.Data.Constants;
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
        public static string Subjective => SubjectiveConstants.CareChargeReclaimSubjectiveCode;

        public ReclaimType Type
        {
            get => _type;
            set => _type = value != _type ? _type : value;
        }

        public ReclaimStatus Status
        {
            get => CalculateStatus();
            set => _status = value;
        }

        // TODO: VK: Move to Core/ReclaimStatusCalculator
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
    }
}
