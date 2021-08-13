using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class HomeCareSupplierCost : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [ForeignKey(nameof(HomeCareServiceTypeId))]
        public HomeCareServiceType HomeCareServiceType { get; set; }

        /// <summary>
        /// Gets or sets the Carer Type Id
        /// </summary>
        public int? CarerTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Services
        /// </summary>
        [ForeignKey(nameof(CarerTypeId))]
        public CarerType CarerType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is secondary carer.
        /// </summary>
        public bool IsSecondaryCarer { get; set; }

        /// <summary>
        /// Gets or sets the Cost Per Hour
        /// </summary>
        public decimal CostPerHour { get; set; }
    }
}
