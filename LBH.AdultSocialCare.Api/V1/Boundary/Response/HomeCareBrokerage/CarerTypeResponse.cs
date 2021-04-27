using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Response.HomeCareBrokerage
{
    public class CarerTypeResponse
    {
        public int CarerTypeId { get; set; }

        // 30m Call, 45m Call, 60m+ Call
        public string CarerTypeName { get; set; }
    }
}
