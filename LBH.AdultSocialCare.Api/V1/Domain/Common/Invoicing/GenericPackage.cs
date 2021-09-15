using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing
{
    public class GenericPackage
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public int? SupplierId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? PaidUpTo { get; set; }
        public BrokerageInfo BrokerageInfo { get; set; }
        public PackageCareChargeDomain CareCharge { get; set; }

        public object OriginalPackage { get; set; }
    }
}
