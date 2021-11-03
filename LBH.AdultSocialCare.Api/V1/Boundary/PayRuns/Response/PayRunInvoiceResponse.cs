using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response
{
    public class PayRunInvoiceResponse
    {
        public Guid Id { get; set; }
        public Guid ServiceUserId { get; set; }
        public string ServiceUserName { get; set; }
        public Guid InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int PackageTypeId { get; set; }
        public string PackageType { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal NetTotal { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
        public Guid CarePackageId { get; set; }
        public string AssignedBrokerName { get; set; }
        public IEnumerable<PayRunInvoiceItemResponse> InvoiceItems { get; set; }
    }
}
