namespace HttpServices.Models.Responses
{
    public class PayRunDetailsResponse
    {
        public PayRunFlatResponse PayRunDetails { get; set; }
        public PagedInvoiceResponse Invoices { get; set; }
    }
}
