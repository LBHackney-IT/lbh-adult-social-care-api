using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareApproveBrokeredBoundary.Request
{
    public class ResidentialCareRequestMoreInformationForCreationRequest
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
