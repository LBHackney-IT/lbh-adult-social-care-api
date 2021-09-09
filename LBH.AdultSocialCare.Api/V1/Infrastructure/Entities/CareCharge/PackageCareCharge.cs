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
        public bool IsProvisional { get; set; }
        [ForeignKey(nameof(PackageTypeId))] public Package Package { get; set; }
        public virtual ICollection<CareChargeElement> CareChargeElements { get; set; }
    }
}
