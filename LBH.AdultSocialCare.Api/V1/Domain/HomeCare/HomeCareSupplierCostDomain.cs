using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCare
{
    public class HomeCareSupplierCostDomain
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Id
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Service Type Id
        /// </summary>
        public int HomeCareServiceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the HomeCare Service Type
        /// </summary>
        public HomeCareServiceType HomeCareServiceType { get; set; }

        /// <summary>
        /// Gets or sets the Carer Type Id
        /// </summary>
        public int? CarerTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Services
        /// </summary>
        public CarerTypeDomain CarerType { get; set; }

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

        /// <summary>
        /// Gets or sets the Updater Id
        /// </summary>
        public Guid? UpdaterId { get; set; }
    }
}
