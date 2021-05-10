using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Request
{
    public class SupplierCostCreationRequest
    {
        public int SupplierId { get; set; }

        public int HomeCareServiceTypeId { get; set; }

        public int? CarerTypeId { get; set; }

        public bool IsSecondaryCarer { get; set; }

        public decimal CostPerHour { get; set; }

        public int CreatorId { get; set; }
    }
}
