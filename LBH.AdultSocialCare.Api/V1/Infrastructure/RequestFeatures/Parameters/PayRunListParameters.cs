using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
{
    public class PayRunListParameters : RequestParameters
    {
        public string PayRunId { get; set; }
        public PayrunType? PayRunType { get; set; }
        public PayrunStatus? PayRunStatus { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
    }
}
