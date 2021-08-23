using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.Common
{
    public class SupplierCreationDomain
    {
        /// <summary>
        /// Gets or sets the Supplier Name
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the Package Type Id
        /// </summary>
        public int PackageTypeId { get; set; }

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
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updater Id
        /// </summary>
        public Guid? UpdaterId { get; set; }
    }
}
