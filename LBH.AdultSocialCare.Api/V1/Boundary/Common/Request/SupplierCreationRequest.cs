using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class SupplierCreationRequest
    {
        [Required] public string SupplierName { get; set; }
        [Required] public int PackageTypeId { get; set; }
        [Required] public bool? IsSupplierInternal { get; set; }
        [Required] public bool? HasSupplierFrameworkContractedRates { get; set; }
    }
}
