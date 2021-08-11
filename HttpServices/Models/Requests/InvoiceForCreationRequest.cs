using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HttpServices.Models.Requests
{
    public class InvoiceForCreationRequest
    {
        [Required] public long? SupplierId { get; set; }
        [Required] public int? PackageTypeId { get; set; }
        [Required] public Guid? ServiceUserId { get; set; }
        [Required] public Guid? CreatorId { get; set; }
        [Required] public DateTimeOffset? DateFrom { get; set; }
        [Required] public DateTimeOffset? DateTo { get; set; }
        public Guid? PackageId { get; set; }
        public IEnumerable<InvoiceItemForCreationRequest> InvoiceItems { get; set; }
    }
}
