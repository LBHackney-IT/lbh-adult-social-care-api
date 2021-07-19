using System;
using System.ComponentModel.DataAnnotations;

namespace HttpServices.Models.Requests
{
    public class InvoiceItemForCreationRequest
    {
        [Required] public string ItemName { get; set; }
        [Required] public decimal? PricePerUnit { get; set; }
        [Required] public int? Quantity { get; set; }
        public Guid? SupplierReturnItemId { get; set; }
        [Required] public Guid? CreatorId { get; set; }
    }
}
