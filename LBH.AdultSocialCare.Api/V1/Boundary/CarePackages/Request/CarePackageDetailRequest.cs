using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CarePackageDetailDomain))]
    [GenerateListMappingFor(typeof(CarePackageDetail))]
    public class CarePackageDetailRequest : IValidatableObject
    {
        [GuidNotEmpty]
        public Guid? Id { get; set; }

        [Required]
        public PackageDetailType Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(13, 2)")]
        [Range(0.01, Double.PositiveInfinity)]
        public decimal? Cost { get; set; }

        [Required]
        public PaymentPeriod CostPeriod { get; set; }

        [Required]
        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((Type is PackageDetailType.AdditionalNeed) && (CostPeriod is PaymentPeriod.OneOff))
            {
                if (EndDate is null)
                {
                    yield return new ValidationResult(
                        "End Date is required for One-Off Additional Need",
                        new[] { nameof(EndDate) });
                }
            }

            if (StartDate?.Date > EndDate?.Date)
            {
                yield return new ValidationResult(
                    "End Date should be later than start date",
                    new[] { nameof(StartDate), nameof(EndDate) });
            }
        }
    }
}
