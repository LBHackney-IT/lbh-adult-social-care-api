using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCare
{
    public class HomeCareSupplierCostCreationDomain
    {
        /// <summary>
        /// Gets or sets the Supplier Id
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Service Type Id
        /// </summary>
        public int HomeCareServiceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Carer Type Id
        /// </summary>
        public int? CarerTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is secondary carer.
        /// </summary>
        public bool IsSecondaryCarer { get; set; }

        /// <summary>
        /// Gets or sets the Cost Per Hour
        /// </summary>
        public decimal CostPerHour { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid CreatorId { get; set; }
    }
}