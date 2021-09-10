using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class PackageCareChargePlainDomain
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public int PackageTypeId { get; set; }
        public int SupplierId { get; set; }
        public Guid ServiceUserId { get; set; }
        public bool IsProvisional { get; set; }
    }
}
