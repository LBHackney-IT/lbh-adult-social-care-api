using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SupplierDomain
    {
        public int Id { get; set; }

        public string SupplierName { get; set; }

        public string Address { get; set; }

        public int PackageTypeId { get; set; }

        public bool IsSupplierInternal { get; set; }

        public bool HasSupplierFrameworkContractedRates { get; set; }
    }
}
