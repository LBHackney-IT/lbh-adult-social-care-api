using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    public class SupplierCreationRequest
    {
        [Required] public string SupplierName { get; set; }
        [Required] public int PackageTypeId { get; set; }
    }
}
