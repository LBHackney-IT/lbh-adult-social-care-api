using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.DayCare
{
    public class DayCareRequestMoreInformationDomain
    {
        /// <summary>
        /// Gets or sets the Day Care Package Id
        /// </summary>
        public Guid DayCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Information Text
        /// </summary>
        public string InformationText { get; set; }
    }
}
