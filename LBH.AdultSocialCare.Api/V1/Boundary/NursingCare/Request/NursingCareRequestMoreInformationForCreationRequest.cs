using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request
{
    public class NursingCareRequestMoreInformationForCreationRequest
    {
        /// <summary>
        /// Gets or sets the Nursing Care Package Id
        /// </summary>
        public Guid NursingCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Information Text
        /// </summary>
        public string InformationText { get; set; }
    }
}
