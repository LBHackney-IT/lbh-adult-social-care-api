using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge
{
    public class PackageCareCharge : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid NursingCarePackageId { get; set; }
        public int PackageTypeId { get; set; }
        public string ClaimReasons { get; set; }
        public bool IsProvisional { get; set; }
        [ForeignKey(nameof(PackageTypeId))] public Package Package { get; set; }
        public virtual ICollection<CareChargeElement> CareChargeElements { get; set; }
    }
}
