using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    [GenerateMappingFor(typeof(CarePackagePlainDomain))]
    [GenerateListMappingFor(typeof(CarePackagePlainDomain))]
    public class CarePackage : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public PackageType PackageType { get; set; }
        public Guid ServiceUserId { get; set; }
        public int? SupplierId { get; set; }
        public string PrimarySupportReason { get; set; }
        public string PackagingScheduling { get; set; } // TODO: VK: too complex for string?
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public AppConstants.Enums.PackageStatus Status { get; set; }    // TODO: VK: Remove alias after legacy PackageStatus will be removed
        public PackageStage Stage { get; set; }

        [ForeignKey(nameof(ServiceUserId))] public Client ServiceUser { get; set; }         // TODO: VK: Client or ServiceUser?
        [ForeignKey(nameof(SupplierId))] public Supplier Supplier { get; set; }
        public NursingCarePackageSettings NursingCareSettings { get; set; }
        public ResidentialCarePackageSettings ResidentialCareSettings { get; set; }
        public virtual ICollection<CarePackageDetail> Details { get; set; }
        public virtual ICollection<CarePackageReclaim> Reclaims { get; set; }
        public virtual ICollection<CarePackageHistory> Histories { get; set; }
    }
}
