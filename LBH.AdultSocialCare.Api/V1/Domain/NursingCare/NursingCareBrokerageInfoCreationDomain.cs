using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCare
{
    public class NursingCareBrokerageInfoCreationDomain
    {
        public Guid NursingCarePackageId { get; set; }
        public int SupplierId { get; set; }
        public int StageId { get; set; }
        public decimal NursingCore { get; set; }
        public Guid CreatorId { get; set; }
        public IEnumerable<NursingCareAdditionalNeedsCostCreationDomain> NursingCareAdditionalNeedsCosts { get; set; }
    }
}
