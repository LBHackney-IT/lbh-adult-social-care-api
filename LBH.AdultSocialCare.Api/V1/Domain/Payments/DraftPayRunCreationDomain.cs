using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.AppConstants.Enums;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Payments;

namespace LBH.AdultSocialCare.Api.V1.Domain.Payments
{
    [GenerateMappingFor(typeof(Payrun))]
    public class DraftPayRunCreationDomain
    {
        public PayrunType Type { get; set; }
        public PayrunStatus Status { get; set; }
        public DateTimeOffset PaidUpToDate { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}
