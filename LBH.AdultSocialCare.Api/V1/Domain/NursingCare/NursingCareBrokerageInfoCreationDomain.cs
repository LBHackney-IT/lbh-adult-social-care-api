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
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public IEnumerable<NursingCareAdditionalNeedsCostCreationDomain> NursingCareAdditionalNeedsCosts { get; set; }
        public int FundedNursingCareCollectorId { get; set; }
    }
}
