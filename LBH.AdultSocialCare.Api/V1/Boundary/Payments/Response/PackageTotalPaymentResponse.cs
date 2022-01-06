using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PackageTotalPaymentResponse
    {
        public Guid PackageId { get; set; }
        public decimal TotalPaid { get; set; }
        public DateTimeOffset DateTo { get; set; }
    }
}
