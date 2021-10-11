using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class Supplier : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Name
        /// </summary>
        public string SupplierName { get; set; }

        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Package Type Id
        /// </summary>
        public int PackageTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Package Type Id
        /// </summary>
        [ForeignKey(nameof(PackageTypeId))]
        public Package Package { get; set; }

        /// <summary>
        /// Gets or sets the Is Supplier Internal
        /// </summary>
        public bool IsSupplierInternal { get; set; }

        /// <summary>
        /// Gets or sets the Has Supplier Framework Contracted Rates
        /// </summary>
        public bool HasSupplierFrameworkContractedRates { get; set; }

        /// <summary>
        /// Gets or sets identifier of default Funded Nursing Care Collector
        /// </summary>
        public int? FundedNursingCareCollectorId { get; set; }

        /// <summary>
        /// Gets or sets a reference to the default Funded Nursing Care Collector instance
        /// </summary>
        [ForeignKey(nameof(FundedNursingCareCollectorId))]
        public FundedNursingCareCollector FundedNursingCareCollector { get; set; }
    }
}
