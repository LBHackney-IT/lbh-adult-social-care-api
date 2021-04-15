using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare
{

    /// <summary>
    /// The home care service type minutes entries.
    /// Used to determine the minute options for the corresponding service type.
    /// </summary>
    public class HomeCareServiceTypeMinutes
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the minutes.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is secondary carer.
        /// </summary>
        public bool IsSecondaryCarer { get; set; }

        /// <summary>
        /// Gets or sets the home care service type identifier.
        /// </summary>
        public int HomeCareServiceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the home care service.
        /// </summary>
        [ForeignKey(nameof(HomeCareServiceTypeId))]
        public HomeCareServiceType HomeCareServiceType { get; set; }

    }

}
