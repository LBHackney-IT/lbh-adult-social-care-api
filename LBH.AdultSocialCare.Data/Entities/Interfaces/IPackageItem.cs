using System;

namespace LBH.AdultSocialCare.Data.Entities.Interfaces
{
    public interface IPackageItem
    {
        public Guid Id { get; set; }
        public Guid CarePackageId { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
