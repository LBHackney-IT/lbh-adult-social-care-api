using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CareChargeElementResponse
    {
        public Guid Id { get; set; }
        public Guid CareChargeId { get; set; }
        public int? StatusId { get; set; }
        public string Status { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public decimal Amount { get; set; }
    }
}
