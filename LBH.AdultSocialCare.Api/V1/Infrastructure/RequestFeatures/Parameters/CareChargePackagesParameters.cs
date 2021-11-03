using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
{
    public class CareChargePackagesParameters : RequestParameters
    {
        public string Status { get; set; }
        public string OrderByDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
