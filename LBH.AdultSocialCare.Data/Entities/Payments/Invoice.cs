using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.Data.Entities.Common;

namespace LBH.AdultSocialCare.Data.Entities.Payments
{
    public class Invoice : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Number { get; set; }

        public int SupplierId { get; set; }
        public Guid ServiceUserId { get; set; }
        public Guid PackageId { get; set; }

        [Column(TypeName = "decimal(13, 2)")] public decimal TotalCost { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal GrossTotal { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal NetTotal { get; set; }

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
