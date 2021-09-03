using System;
using System.ComponentModel.DataAnnotations;

namespace HttpServices.Models.Requests
{
    public class InvoiceItemForCreationRequest
    {
        [Required] public string ItemName { get; set; }
        [Required] public decimal? PricePerUnit { get; set; }
        [Required] public decimal? Quantity { get; set; }
        [Required] public string PriceEffect { get; set; }
        public string ClaimedBy { get; set; }
        public string ReclaimedFrom { get; set; }
        public Guid? SupplierReturnItemId { get; set; }
        [Required] public Guid? CreatorId { get; set; }
    }
}
