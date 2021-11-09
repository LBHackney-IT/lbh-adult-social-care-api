using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    public class PayRunInvoiceDomain
    {
        public Guid InvoiceId { get; set; }
        public Guid CarePackageId { get; set; }
        public Guid ServiceUserId { get; set; }
        public string ServiceUserName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNumber { get; set; }
        public PackageType PackageType { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public string AssignedBrokerName { get; set; }
        public IEnumerable<PayRunInvoiceItemDomain> InvoiceItems { get; set; }
    }
}
