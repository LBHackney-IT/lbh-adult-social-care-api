using Common.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class DraftPayRunCreationDomain
    {
        public PayrunType Type { get; set; }
        public PayrunStatus Status { get; set; }
        public DateTimeOffset? PaidFromDate { get; set; }
        public DateTimeOffset PaidUpToDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate => PaidUpToDate;
    }
}
