using System;
using LBH.AdultSocialCare.Api.Attributes;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    [GenerateListMappingFor(typeof(CarePackageDetail))]
    public class CarePackageDetailDomain
    {
        public PackageDetailType Type { get; set; }

        public decimal? Cost { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string ServiceUserNeeds { get; set; }
    }
}
