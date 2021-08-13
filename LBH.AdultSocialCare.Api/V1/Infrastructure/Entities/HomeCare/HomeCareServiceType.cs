using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare
{

    /// <summary>
    /// Services object
    /// </summary>
    public class HomeCareServiceType : BaseEntityTmp
    {

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Service Name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the minutes for this service type.
        /// </summary>
        public ICollection<HomeCareServiceTypeMinutes> Minutes { get; set; }

    }

}
