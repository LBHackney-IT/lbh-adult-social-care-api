using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
{
    public class PayRunDetailsQueryParameters : RequestParameters
    {
        public int? PackageType { get; set; }
        public int? InvoiceStatus { get; set; }
        public string SearchTerm { get; set; }
        public DateTimeOffset? FromDate { get; set; }
        public DateTimeOffset? ToDate { get; set; }
    }
}
