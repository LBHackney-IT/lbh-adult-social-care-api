using Common.AppConstants.Enums;
using System;
using LBH.AdultSocialCare.Data.Constants.Enums;

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
