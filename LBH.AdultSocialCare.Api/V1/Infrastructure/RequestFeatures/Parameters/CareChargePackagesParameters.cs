using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
{
    public class CareChargePackagesParameters : RequestParameters
    {
        public string Status { get; set; }
        public string OrderByDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool? IsS117ClientConfirmed { get; set; }
    }
}
