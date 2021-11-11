using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Functions.Payruns.Enums;
using LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.CarePackages
{
    public class CarePackage : BaseEntity
    {
        public CarePackage()
        {
            Details = new List<CarePackageDetail>();
            Reclaims = new List<CarePackageReclaim>();
            Histories = new List<CarePackageHistory>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public PackageType PackageType { get; set; }
        public PackageStatus Status { get; set; }

        public Guid ServiceUserId { get; set; }
        public int? SupplierId { get; set; }
        public Guid? ApproverId { get; set; }
        public DateTimeOffset? DateApproved { get; set; } // Date the package is approved
        public Guid? BrokerId { get; set; }
        public DateTimeOffset? DateAssigned { get; set; } // Date package is assigned to broker

        public int? PrimarySupportReasonId { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public CarePackageSettings Settings { get; set; }

        public string SocialWorkerCarePlanFileUrl { get; set; }

        [ForeignKey(nameof(ServiceUserId))]
        public ServiceUser ServiceUser { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Supplier { get; set; }

        [ForeignKey(nameof(ApproverId))]
        public User Approver { get; set; }

        [ForeignKey(nameof(BrokerId))]
        public User Broker { get; set; }

        [ForeignKey(nameof(PrimarySupportReasonId))]
        public PrimarySupportReason PrimarySupportReason { get; set; }

        public virtual ICollection<CarePackageDetail> Details { get; set; }
        public virtual ICollection<CarePackageReclaim> Reclaims { get; set; }
        public virtual ICollection<CarePackageHistory> Histories { get; set; }
    }
}
