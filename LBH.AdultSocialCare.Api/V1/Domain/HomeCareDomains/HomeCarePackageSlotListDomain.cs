using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareDomains
{

    public class HomeCarePackageSlotListDomain
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        public Guid HomeCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Slots
        /// </summary>
        public List<HomeCarePackageSlotDomain> HomeCarePackageSlots { get; set; }

    }

}
