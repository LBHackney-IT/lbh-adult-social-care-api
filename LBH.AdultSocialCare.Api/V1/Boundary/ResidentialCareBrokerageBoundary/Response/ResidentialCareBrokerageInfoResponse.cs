using LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareAdditionalNeedsBoundary.Response;
using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCareBrokerageBoundary.Response
{
    public class ResidentialCareBrokerageInfoResponse
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
        /// Gets or sets the Residential Care Package
        /// </summary>
        public ResidentialCarePackageResponse ResidentialCarePackage { get; set; }

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
