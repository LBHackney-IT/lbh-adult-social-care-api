using System;
using System.Collections.Generic;

namespace HttpServices.Models.Requests
{
    public class BillCreationRequest
    {
        public int PackageTypeId { get; set; }
        public Guid PackageId { get; set; }
        public string SupplierRef { get; set; }
        public long SupplierId { get; set; }
        public DateTimeOffset ServiceFromDate { get; set; }
        public DateTimeOffset ServiceToDate { get; set; }
        public DateTimeOffset DateBilled { get; set; }
        public DateTimeOffset BillDueDate { get; set; }
        public decimal TotalBilled { get; set; }
        public int BillPaymentStatusId { get; set; }

        public Guid? CreatorId { get; set; }
        public List<BillItemCreationRequest> BillItems { get; set; }
    }
}
