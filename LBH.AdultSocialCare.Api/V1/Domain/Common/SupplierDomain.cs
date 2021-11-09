namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SupplierDomain
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string CedarName { get; set; }
        public string CedarReferenceNumber { get; set; }
        public int? CedarId { get; set; }
    }
}
