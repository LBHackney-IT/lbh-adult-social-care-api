using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    public class FinancialAssessmentViewResponse
    {
        public IEnumerable<CarePackageReclaimResponse> CareCharges { get; set; }
        public CarePackageResourceResponse Resource { get; set; }
    }
}
