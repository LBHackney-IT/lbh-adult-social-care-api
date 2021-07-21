using System;
using System.Collections.Generic;

namespace HttpServices.Models.Responses
{
    public class BillResponse
    {
        public long BillId { get; set; }
        public int PackageTypeId { get; set; }
        public Guid PackageId { get; set; }
        public string SupplierRef { get; set; }
        public long SupplierId { get; set; }
        public DateTimeOffset ServiceFromDate { get; set; }
        public DateTimeOffset ServiceToDate { get; set; }
        public DateTimeOffset DateBilled { get; set; }
        public DateTimeOffset BillDueDate { get; set; }
        public decimal TotalBilled { get; set; }
        public decimal PaidAmount { get; set; }
        public int BillPaymentStatusId { get; set; }

        public PackageTypeResponse PackageType { get; set; }

        public BillStatusResponse BillStatus { get; set; }
        public SupplierMinimalResponse Supplier { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdaterId { get; set; }
        public List<BillItemResponse> BillItems { get; set; }
    }
}
