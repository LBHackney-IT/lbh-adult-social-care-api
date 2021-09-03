using System;

namespace HttpServices.Models.Responses
{
    public class InvoiceItemMinimalResponse
    {
        public Guid InvoiceItemId { get; set; }
        public Guid InvoiceId { get; set; }
        public int InvoiceItemPaymentStatusId { get; set; }
        public string ItemName { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public decimal VatAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public string PriceEffect { get; set; }
        public string ClaimedBy { get; set; }
        public string ReclaimedFrom { get; set; }
        public Guid? SupplierReturnItemId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
    }
}
