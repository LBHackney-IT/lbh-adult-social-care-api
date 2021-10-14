using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageDomain))]
    [GenerateMappingFor(typeof(CarePackagePlainDomain))]
    [GenerateListMappingFor(typeof(CarePackagePlainDomain))]
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
        public Guid? BrokerId { get; set; }

        public int PrimarySupportReasonId { get; set; }
        public PackageScheduling PackageScheduling { get; set; }
        public CarePackageSettings Settings { get; set; }

        [ForeignKey(nameof(ServiceUserId))]
        public Client ServiceUser { get; set; }

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
