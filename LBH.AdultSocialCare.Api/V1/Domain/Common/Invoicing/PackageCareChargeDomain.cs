using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common.Invoicing
{
    public class PackageCareChargeDomain
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public int PackageTypeId { get; set; }
        public bool IsProvisional { get; set; }
        public ICollection<CareChargeElementDomain> CareChargeElements { get; set; }
    }
}
