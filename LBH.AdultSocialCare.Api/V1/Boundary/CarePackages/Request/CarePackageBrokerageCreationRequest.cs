using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CarePackageBrokerageDomain))]
    public class CarePackageBrokerageCreationRequest : IValidatableObject
    {
        [Required]
        [Column(TypeName = "decimal(13, 2)")]
        [Range(0.01, Double.PositiveInfinity)]
        public decimal? CoreCost { get; set; }

        [Required]
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public int? SupplierId { get; set; }

        public List<CarePackageDetailRequest> Details { get; set; } = new List<CarePackageDetailRequest>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Details.Any(d => d.Type == PackageDetailType.CoreCost))
            {
                yield return new ValidationResult(
                    $"Package Details should not contain any item of type Core Cost ({PackageDetailType.CoreCost})",
                    new[] { nameof(Details) });
            }

            // ANP not outside core package dates
            foreach (var carePackageDetail in Details)
            {
                if (carePackageDetail.StartDate.GetValueOrDefault().Date < StartDate.GetValueOrDefault().Date)
                {
                    yield return new ValidationResult($"ANP start date cannot be before core cost start date", new[] { nameof(Details) });
                }

                if (EndDate != null && carePackageDetail.EndDate.GetValueOrDefault().Date > EndDate.GetValueOrDefault().Date)
                {
                    yield return new ValidationResult($"ANP end date cannot be after core cost end date", new[] { nameof(Details) });
                }
            }
        }
    }
}
