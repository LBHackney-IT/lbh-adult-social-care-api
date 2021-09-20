using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    public class CarePackageDetail : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public int PackageTypeId { get; set; }

        public string PackageDetailType { get; set; }   // TODO: VK: TBD

        public string ServiceUserNeeds { get; set; }

        public string Period { get; set; }              // TODO: VK: TBD

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        public string CostPer { get; set; }            // TODO: VK: TBD

        public string UnitOfMeasure { get; set; }

        public CarePackage Package { get; set; }
    }
}
