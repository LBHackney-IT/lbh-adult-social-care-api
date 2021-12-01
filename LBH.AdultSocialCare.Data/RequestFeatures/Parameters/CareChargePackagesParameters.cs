using System;

namespace LBH.AdultSocialCare.Data.RequestFeatures.Parameters
{
    public class CareChargePackagesParameters : RequestParameters
    {
        public string Status { get; set; }
        public string OrderByDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
