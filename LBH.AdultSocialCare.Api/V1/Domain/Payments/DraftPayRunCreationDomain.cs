using System;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class DraftPayRunCreationDomain
    {
        public PayrunType Type { get; set; }
        public PayrunStatus Status { get; set; }
        public DateTime? PaidFromDate { get; set; }
        public DateTime PaidUpToDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate => PaidUpToDate;
    }
}
