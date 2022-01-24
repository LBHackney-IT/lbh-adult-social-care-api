using System;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Data.Entities.Interfaces
{
    public interface IPackageItem
    {
        public Guid Id { get; set; }
        public Guid CarePackageId { get; set; }

        public decimal Cost { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }

        CarePackage Package { get; set; }

        public long Version { get; set; }
    }
}
