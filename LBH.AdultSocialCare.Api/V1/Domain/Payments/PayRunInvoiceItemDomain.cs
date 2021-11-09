using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
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
