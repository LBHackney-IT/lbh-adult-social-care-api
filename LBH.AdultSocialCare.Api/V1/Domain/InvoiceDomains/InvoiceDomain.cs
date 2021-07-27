using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.InvoiceDomains
{
    public class InvoiceDomain
    {
        public long? SupplierId { get; set; }
        public int? PackageTypeId { get; set; }
        public Guid? ServiceUserId { get; set; }
        public Guid? CreatorId { get; set; }
        public IEnumerable<InvoiceItemDomain> InvoiceItems { get; set; }
    }
}
