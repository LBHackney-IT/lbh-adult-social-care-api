using System;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters
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
