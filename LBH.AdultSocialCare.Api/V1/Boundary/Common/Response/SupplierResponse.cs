namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class SupplierResponse
    {
        public int Id { get; set; }

        public string SupplierName { get; set; }

        public int PackageTypeId { get; set; }

        public PackageResponse Package { get; set; }

        public bool IsSupplierInternal { get; set; }

        public bool HasSupplierFrameworkContractedRates { get; set; }

        public int CreatorId { get; set; }

        public int UpdatorId { get; set; }
    }
}
