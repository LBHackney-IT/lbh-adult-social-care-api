using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCareBrokerageDomains
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

        /// <summary>
        /// Gets or sets the Additional Needs Payment
        /// </summary>
        public decimal AdditionalNeedsPayment { get; set; }

        /// <summary>
        /// Gets or sets the Additional Needs Payment One Off
        /// </summary>
        public decimal AdditionalNeedsPaymentOneOff { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }
    }
}
