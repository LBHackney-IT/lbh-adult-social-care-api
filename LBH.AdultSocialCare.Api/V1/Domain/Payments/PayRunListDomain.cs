using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    [GenerateListMappingFor(typeof(PayRunListResponse))]
    public class PayRunListDomain
    {
        public Guid PayRunId { get; set; }
        public string PayRunNumber { get; set; }
        public int PayRunTypeId { get; set; }
        public string PayRunTypeName { get; set; }
        public int PayRunStatusId { get; set; }
        public string PayRunStatusName { get; set; }
        public decimal? TotalAmountPaid { get; set; }
        public decimal? TotalAmountHeld { get; set; }
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
