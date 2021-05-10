using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.SupplierDomains
{
    public class SupplierDomain
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Name
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the Package Type Id
        /// </summary>
        public int PackageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Package Type Id
        /// </summary>
        public PackageDomain Package { get; set; }

        /// <summary>
        /// Gets or sets the Is Supplier Internal
        /// </summary>
        public bool IsSupplierInternal { get; set; }

        /// <summary>
        /// Gets or sets the Has Supplier Framework Contracted Rates
        /// </summary>
        public bool HasSupplierFrameworkContractedRates { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }
    }
}
