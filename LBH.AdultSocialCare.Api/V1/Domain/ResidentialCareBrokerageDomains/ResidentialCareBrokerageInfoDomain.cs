using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCarePackageDomains;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains
{
    public class ResidentialCareBrokerageInfoDomain
    {
        /// <summary>
        /// Gets or sets the Residential Care Brokerage Id
        /// </summary>
        public Guid ResidentialCareBrokerageId { get; set; }

        /// <summary>
        /// Gets or sets the Residential Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Residential Care package
        /// </summary>
        public ResidentialCarePackageDomain ResidentialCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Residential Core Per Week
        /// </summary>
        public decimal ResidentialCore { get; set; }

        public int? StageId { get; set; }
        public int? SupplierId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid? UpdatorId { get; set; }
        public IEnumerable<ResidentialCareAdditionalNeedsCostDomain> ResidentialCareAdditionalNeedsCosts { get; set; }
    }
}
