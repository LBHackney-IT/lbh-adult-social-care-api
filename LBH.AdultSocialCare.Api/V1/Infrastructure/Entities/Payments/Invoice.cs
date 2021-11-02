using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments
{
    public class Invoice : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Number { get; set; }

        public int SupplierId { get; set; }
        public Guid ServiceUserId { get; set; }

        public decimal TotalCost { get; set; }

        public virtual ICollection<InvoiceItem> Items { get; set; }
        public virtual ICollection<PayrunInvoice> PayrunInvoices { get; set; }
    }
}
