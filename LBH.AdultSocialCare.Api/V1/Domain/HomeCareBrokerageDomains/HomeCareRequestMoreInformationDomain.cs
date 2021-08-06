using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains
{
    public class HomeCareRequestMoreInformationDomain
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
