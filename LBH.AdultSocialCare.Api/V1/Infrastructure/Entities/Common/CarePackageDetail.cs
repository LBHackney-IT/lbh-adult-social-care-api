using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Request;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    [GenerateListMappingFor(typeof(CarePackageDetailRequest))]
    [GenerateListMappingFor(typeof(CarePackageDetailResponse))]
    public class CarePackageDetail : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public PackageDetailType Type { get; set; }

        [Column(TypeName = "decimal(13, 2)")]
        public decimal Cost { get; set; }

        public PaymentPeriod CostPeriod { get; set; }
        public PaymentPeriod ServicePeriod { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public string UnitOfMeasure { get; set; }

        [ForeignKey(nameof(CarePackageId))]
        public CarePackage Package { get; set; }
    }
}
