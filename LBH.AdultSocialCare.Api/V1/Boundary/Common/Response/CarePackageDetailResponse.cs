using System;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Common.Response
{
    public class CarePackageDetailResponse
    {
        public Guid Id { get; set; }

        public PackageDetailType Type { get; set; }

        public decimal Cost { get; set; }

        public PaymentPeriod CostPeriod { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
