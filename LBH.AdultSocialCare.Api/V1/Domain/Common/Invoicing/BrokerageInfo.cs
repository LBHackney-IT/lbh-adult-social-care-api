using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing
{
    public class BrokerageInfo
    {
        public decimal Core { get; set; }
        public ICollection<AdditionalNeedsCost> AdditionalNeedsCosts { get; set; }
    }
}
