using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Validations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request
{
    [GenerateMappingFor(typeof(CareChargesCreateDomain))]
    public class CareChargesCreationRequest : IValidatableObject
    {
        public IList<CareChargeReclaimCreationRequest> CareCharges { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CareCharges.Count == 0)
            {
                yield return new ValidationResult(
                    "At least one care charge must be provided",
                    new[] { nameof(CareCharges) });
            }
        }
    }
}
