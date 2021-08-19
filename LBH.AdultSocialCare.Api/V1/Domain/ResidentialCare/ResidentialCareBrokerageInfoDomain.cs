using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareBrokerageInfoDomain
    {
        /// <summary>
        /// Gets or sets the Residential Care Brokerage Id
        /// </summary>
        public Guid Id { get; set; }

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

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }
    }
}
