using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages
{
    public class CarePackageHistory : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Guid CarePackageId { get; set; }

        public string Description { get; set; }
        public string RequestMoreInformation { get; set; }

        public HistoryStatus Status { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage CarePackage { get; set; }
    }
}
