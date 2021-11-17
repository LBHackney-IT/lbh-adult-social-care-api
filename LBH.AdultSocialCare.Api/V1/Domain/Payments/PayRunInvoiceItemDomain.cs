using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Boundary.Payments.Response;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    [GenerateListMappingFor(typeof(PayRunInvoiceItemResponse))]
    public class PayRunInvoiceItemDomain
    {
        public Guid Id { get; set; } // Invoice item id
        public string Name { get; set; }
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
        public decimal Cost { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsReclaim { get; set; }
        public ClaimCollector ClaimCollector { get; set; }
        public PriceEffect PriceEffect { get; set; }
    }
}
