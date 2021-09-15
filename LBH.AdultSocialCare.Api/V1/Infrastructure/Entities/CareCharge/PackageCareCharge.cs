using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge
{
    public class PackageCareCharge : BaseEntity
    {
        [Key] public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public int PackageTypeId { get; set; }
        public int SupplierId { get; set; }
        public Guid ServiceUserId { get; set; }
        public bool IsProvisional { get; set; }
        [ForeignKey(nameof(PackageTypeId))] public Package Package { get; set; }
        [ForeignKey(nameof(SupplierId))] public Supplier Supplier { get; set; }
        [ForeignKey(nameof(ServiceUserId))] public Client ServiceUser { get; set; }
        public virtual ICollection<CareChargeElement> CareChargeElements { get; set; }
    }
}
