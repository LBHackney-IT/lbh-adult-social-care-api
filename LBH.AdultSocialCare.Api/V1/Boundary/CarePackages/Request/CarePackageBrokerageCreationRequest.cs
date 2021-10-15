using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CarePackageBrokerageDomain))]
    public class CarePackageBrokerageCreationRequest : IValidatableObject
    {
        [Required]
        [Column(TypeName = "decimal(13, 2)")]
        public decimal? CoreCost { get; set; }

        [Required]
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        public int? SupplierId { get; set; }

        public List<CarePackageDetailRequest> Details { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Details.Any(d => d.Type == PackageDetailType.CoreCost))
            {
                yield return new ValidationResult(
                    $"Package Details should not contain any item of type Core Cost ({PackageDetailType.CoreCost})",
                    new[] { nameof(Details) });
            }
        }
    }
}