namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class SupplierCostCreationRequest
    {
        public int SupplierId { get; set; }

        public int HomeCareServiceTypeId { get; set; }

        public int? CarerTypeId { get; set; }

        public bool IsSecondaryCarer { get; set; }

        public decimal CostPerHour { get; set; }
    }
}
