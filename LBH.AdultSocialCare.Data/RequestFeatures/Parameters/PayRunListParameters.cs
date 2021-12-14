using System;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Data.RequestFeatures.Parameters
{
    public class PayRunListParameters : RequestParameters
    {
        public string SearchTerm { get; set; }
        public PayrunType? PayRunType { get; set; }
        public PayrunStatus? PayRunStatus { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
    }
}
