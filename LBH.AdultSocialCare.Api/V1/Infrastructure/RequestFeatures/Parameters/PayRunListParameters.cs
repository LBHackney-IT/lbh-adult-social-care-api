using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
{
    public class PayRunListParameters : RequestParameters
    {
        public Guid? PayRunId { get; set; }
        public int? PayRunTypeId { get; set; }
        public int? PayRunStatusId { get; set; }
        public DateTimeOffset? DateFrom { get; set; }
        public DateTimeOffset? DateTo { get; set; }
    }
}
