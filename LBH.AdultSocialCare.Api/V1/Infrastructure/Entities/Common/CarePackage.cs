using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    public class CarePackage : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int PackageType { get; set; }

        public Guid ServiceUserId { get; set; }

        public int? SupplierId { get; set; }

        public string PrimarySupportReason { get; set; }

        public string PackagingScheduling { get; set; } // TODO: VK: too complex for string?

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public int StatusId { get; set; }

        public int StageId { get; set; }

        public bool HasReclaim { get; set; }            // TODO: VK: looks like a calculated field

        public string Period { get; set; }              // TODO: VK: TBD

        [ForeignKey(nameof(ServiceUserId))]
        public Client ServiceUser { get; set; }         // TODO: VK: Client or ServiceUser?

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(StatusId))]
        public PackageStatus Status { get; set; }

        [ForeignKey(nameof(StageId))]
        public Stage Stage { get; set; }

        public NursingCarePackageSettings NursingCareSettings { get; set; }

        public ResidentialCarePackageSettings ResidentialCareSettings { get; set; }

        public virtual ICollection<CarePackageDetail> Details { get; set; }

        public virtual ICollection<CarePackageReclaim> Reclaims { get; set; }
    }
}
