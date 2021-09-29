using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateMappingFor(typeof(CarePackageDetail))]
    [GenerateMappingFor(typeof(CarePackageDetailResponse))]
    [GenerateListMappingFor(typeof(CarePackageDetail))]
    public class CarePackageDetailDomain
    {
        public Guid? Id { get; set; }

        public PackageDetailType Type { get; set; }

        public decimal? Cost { get; set; }

        public PaymentPeriod CostPeriod { get; set; }

        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
