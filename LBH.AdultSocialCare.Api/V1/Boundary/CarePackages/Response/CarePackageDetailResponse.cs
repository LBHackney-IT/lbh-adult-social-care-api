using System;
using Common.Attributes;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response
{
    [GenerateListMappingFor(typeof(CarePackageDetail))]
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
