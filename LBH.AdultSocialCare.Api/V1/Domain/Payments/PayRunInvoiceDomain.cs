using System;
using System.Collections.Generic;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class PayRunInvoiceDomain
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid CarePackageId { get; set; }
        public Guid ServiceUserId { get; set; }
        public int HackneyId { get; set; }
        public string ServiceUserName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNumber { get; set; }
        public PackageType PackageType { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public decimal NetTotal { get; set; }
        public decimal GrossTotal { get; set; }
        public string AssignedBrokerName { get; set; }
        public IEnumerable<PayRunInvoiceItemDomain> InvoiceItems { get; set; }
    }
}
