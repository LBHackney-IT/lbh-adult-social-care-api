using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.HomeCare.Request
{
    public class HomeCareRequestMoreInformationForCreationRequest
    {
        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        public Guid HomeCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Information Text
        /// </summary>
        public string InformationText { get; set; }
    }
}
