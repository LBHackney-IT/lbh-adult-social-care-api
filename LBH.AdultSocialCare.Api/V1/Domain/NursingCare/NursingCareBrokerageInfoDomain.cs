using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCare
{
    public class NursingCareBrokerageInfoDomain
    {
        public Guid NursingCareBrokerageId { get; set; }
        public Guid NursingCarePackageId { get; set; }
        public NursingCarePackageDomain NursingCarePackage { get; set; }
        public decimal NursingCore { get; set; }
        public int? StageId { get; set; }
        public int? SupplierId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public IEnumerable<NursingCareAdditionalNeedsCostDomain> NursingCareAdditionalNeedsCosts { get; set; }

    }
}
