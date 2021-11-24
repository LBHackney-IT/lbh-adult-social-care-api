using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Domain
{
    public class InvoiceDomain
    {
        public Guid PackageId { get; set; }

        public InvoiceStatus Status { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public List<InvoiceItem> Items { get; set; }
    }
}
