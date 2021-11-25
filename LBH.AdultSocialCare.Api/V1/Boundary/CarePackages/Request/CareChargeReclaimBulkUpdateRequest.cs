using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    public class CareChargeReclaimBulkUpdateRequest
    {
        public CareChargeReclaimFileRequest FileRequest { get; set; }
        public List<CareChargeReclaimUpdateRequest> Reclaims { get; set; }
    }
}
