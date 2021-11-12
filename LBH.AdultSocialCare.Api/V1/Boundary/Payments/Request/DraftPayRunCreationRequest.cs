using System;
using System.ComponentModel.DataAnnotations;
using Common.AppConstants.Enums;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request
{
    [GenerateMappingFor(typeof(DraftPayRunCreationDomain))]
    public class DraftPayRunCreationRequest
    {
        [Required]
        public PayrunType Type { get; set; }

        public DateTimeOffset? PaidFromDate { get; set; }

        [Required]
        public DateTimeOffset? PaidUpToDate { get; set; }
    }
}
