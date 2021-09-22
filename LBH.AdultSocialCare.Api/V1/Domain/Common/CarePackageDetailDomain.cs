using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class CarePackageDetailDomain
    {
        public Guid Id { get; set; }

        public Guid CarePackageId { get; set; }

        public string PackageDetailType { get; set; }   // TODO: VK: TBD

        public string ServiceUserNeeds { get; set; }

        public PaymentPeriod Period { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public decimal Cost { get; set; }

        public string CostPer { get; set; }            // TODO: VK: TBD

        public string UnitOfMeasure { get; set; }
    }
}
