using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareBrokerageInfoCreationDomain
    {
        /// <summary>
        /// Gets or sets the Residential Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        public int SupplierId { get; set; }
        public int StageId { get; set; }

        /// <summary>
        /// Gets or sets the Residential Core Per Week
        /// </summary>
        public decimal ResidentialCore { get; set; }

        public Guid CreatorId { get; set; }

        public IEnumerable<ResidentialCareAdditionalNeedsCostCreationDomain> ResidentialCareAdditionalNeedsCosts { get; set; }
    }
}
