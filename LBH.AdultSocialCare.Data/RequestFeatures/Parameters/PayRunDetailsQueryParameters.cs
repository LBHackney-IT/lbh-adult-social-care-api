using System;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Data.RequestFeatures.Parameters
{
    public class PayRunDetailsQueryParameters : RequestParameters
    {
        public PackageType? PackageType { get; set; }
        public InvoiceStatus? InvoiceStatus { get; set; }
        public string SearchTerm { get; set; }
        public DateTimeOffset? FromDate { get; set; }
        public DateTimeOffset? ToDate { get; set; }
    }
}
