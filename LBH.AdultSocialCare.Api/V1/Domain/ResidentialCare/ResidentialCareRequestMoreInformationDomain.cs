using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareRequestMoreInformationDomain
    {
        /// <summary>
        /// Gets or sets the Residential Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Information Text
        /// </summary>
        public string InformationText { get; set; }
    }
}