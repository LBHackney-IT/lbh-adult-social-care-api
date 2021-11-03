using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.CarePackages
{
    [GenerateMappingFor(typeof(CarePackageDetail))]
    [GenerateMappingFor(typeof(CarePackageDetailResponse))]
    [GenerateListMappingFor(typeof(CarePackageDetail))]
    public class CarePackageDetailDomain
    {
        public Guid? Id { get; set; }

        public PackageDetailType Type { get; set; }

        public decimal Cost { get; set; }

        public PaymentPeriod CostPeriod { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
