using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Common.AppConstants.Enums;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Payments;
using LBH.AdultSocialCare.Api.V1.Validations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Request
{
    [GenerateMappingFor(typeof(DraftPayRunCreationDomain))]
    public class DraftPayRunCreationRequest
    {
        [Required]
        public PayrunType Type { get; set; }

        [Required]
        public DateTimeOffset PaidUpToDate { get; set; }
    }
}
