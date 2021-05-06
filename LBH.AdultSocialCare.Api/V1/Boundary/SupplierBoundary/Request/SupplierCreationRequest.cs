using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.SupplierBoundary.Request
{
    public class SupplierCreationRequest
    {
        [Required] public string SupplierName { get; set; }
        [Required] public int PackageTypeId { get; set; }
        [Required] public bool? IsSupplierInternal { get; set; }
        [Required] public bool? HasSupplierFrameworkContractedRates { get; set; }
        [Required] public int? CreatorId { get; set; }
    }
}
