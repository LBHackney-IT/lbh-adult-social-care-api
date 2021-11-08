using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response
{
    public class PayRunInvoiceItemResponse
    {
        public Guid Id { get; set; } // Invoice item id
        public string Name { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public decimal Cost { get; set; }
        public int Days { get; set; }
        public decimal Quantity { get; set; }
        public string Period { get; set; } // 1 week 5 days
        public decimal TotalCost { get; set; }
        public bool IsReclaim { get; set; }
        public ClaimCollector ClaimCollector { get; set; }
        public string ClaimCollectorName { get; set; }
    }
}
