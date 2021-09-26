using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Validations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    [GenerateMappingFor(typeof(CarePackageDetailDomain))]
    public class CarePackageDetailRequest
    {
        [GuidNotEmpty]
        public Guid? Id { get; set; }

        // TODO: VK: extend validation to deny out of range enum values, add custom Newtonsoft converter
        [Range(1, 3)]
        [Required]
        public PackageDetailType Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(13, 2)")]
        public decimal? Cost { get; set; }

        [Required]
        [EnumDataType(typeof(PaymentPeriod))]
        public PaymentPeriod CostPeriod { get; set; }

        [Required]
        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string ServiceUserNeeds { get; set; }
    }
}
