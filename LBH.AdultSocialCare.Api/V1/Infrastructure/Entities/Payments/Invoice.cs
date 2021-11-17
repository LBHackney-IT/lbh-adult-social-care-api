using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
{
    public class Invoice : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Number { get; set; }

        public int SupplierId { get; set; }
        public Guid ServiceUserId { get; set; }
        public Guid PackageId { get; set; }

        public decimal TotalCost { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal NetTotal { get; set; }

        [ForeignKey(nameof(PackageId))]
        public CarePackage Package { get; set; }

        [ForeignKey(nameof(ServiceUserId))]
        public ServiceUser ServiceUser { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

        public virtual ICollection<InvoiceItem> Items { get; set; }
        public virtual ICollection<PayrunInvoice> PayrunInvoices { get; set; }
    }
}
