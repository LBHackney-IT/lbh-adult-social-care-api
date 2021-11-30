using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response
{
    public class PayRunInsightsResponse
    {
        public Guid PayRunId { get; set; }
        public PayrunStatus PayRunStatus { get; set; }
        public decimal TotalInvoiceAmount { get; set; }
        public decimal TotalDifferenceFromLastCycle { get; set; }
        public int SupplierCount { get; set; }
        public int ServiceUserCount { get; set; }
        public int HoldsCount { get; set; }
        public decimal TotalHeldAmount { get; set; }
        public bool IsCedarFileDownloaded { get; set; }
        public string PaidBy { get; set; }
        public DateTimeOffset? PaidOn { get; set; }
        public string PayRunStatusName => PayRunStatus.GetDisplayName();
    }
}
