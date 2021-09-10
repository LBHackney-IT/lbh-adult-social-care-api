using LBH.AdultSocialCare.Api.V1.Domain.Common;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareBrokerageForCreationDomain
    {
        public Guid ResidentialCarePackageId { get; set; }
        public int SupplierId { get; set; }
        public int StageId { get; set; }
        public decimal ResidentialCore { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public IEnumerable<ResidentialCareAdditionalNeedsCostCreationDomain> ResidentialCareAdditionalNeedsCosts { get; set; }
        public bool HasCareCharges { get; set; }
        public BrokerageCareChargeForChangeDomain CareChargeSettings { get; set; }
    }
}
