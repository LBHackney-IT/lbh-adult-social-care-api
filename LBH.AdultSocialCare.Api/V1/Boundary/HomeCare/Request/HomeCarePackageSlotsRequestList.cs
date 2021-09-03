using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request
{

    public class HomeCarePackageSlotsRequestList
    {

        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        public Guid HomeCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Slot Response
        /// </summary>
        public List<HomeCarePackageSlotRequest> HomeCarePackageSlots { get; set; }

    }

}
