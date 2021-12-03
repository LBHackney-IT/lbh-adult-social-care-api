using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    public class CareChargesCreateDomain
    {
        public IList<CareChargeReclaimCreationDomain> CareCharges { get; set; }
    }
}
