using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareBrokerageInfoDomain
    {
        public Guid ResidentialCareBrokerageId { get; set; }
        public Guid ResidentialCarePackageId { get; set; }
        public ResidentialCarePackageDomain ResidentialCarePackage { get; set; }
        public decimal ResidentialCore { get; set; }
        public bool HasCareCharges { get; set; }
        public int? StageId { get; set; }
        public int? SupplierId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public IEnumerable<ResidentialCareAdditionalNeedsCostDomain> ResidentialCareAdditionalNeedsCosts { get; set; }
    }
}
