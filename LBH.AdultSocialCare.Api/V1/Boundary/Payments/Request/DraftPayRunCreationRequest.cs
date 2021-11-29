using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Payments.Request
{
    [GenerateMappingFor(typeof(DraftPayRunCreationDomain))]
    public class DraftPayRunCreationRequest
    {
        [Required]
        public PayrunType Type { get; set; }

        public DateTime? PaidFromDate { get; set; }

        [Required]
        public DateTime? PaidUpToDate { get; set; }
    }
}
