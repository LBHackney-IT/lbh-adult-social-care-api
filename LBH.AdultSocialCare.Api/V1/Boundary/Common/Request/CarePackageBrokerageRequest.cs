using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Request
{
    [GenerateMappingFor(typeof(CarePackageBrokerageDomain))]
    public class CarePackageBrokerageRequest : IValidatableObject
    {
        public int? SupplierId { get; set; }

        public List<CarePackageDetailRequest> Details { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Details.Count(d => d.Type == PackageDetailType.CoreCost) != 1)
            {
                yield return new ValidationResult(
                    $"One and only one package detail of type Core Cost ({PackageDetailType.CoreCost}) must be provided",
                    new[] { nameof(Details) });
            }
        }
    }
}
