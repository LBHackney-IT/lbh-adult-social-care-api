using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request
{
    public class ResidentialCareBrokerageCreationRequest
    {
        /// <summary>
        /// Gets or sets the Residential Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Id
        /// </summary>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Stage Id
        /// </summary>
        public int StageId { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Residential Core Per Week
        /// </summary>
        public decimal ResidentialCore { get; set; }

        /// <summary>
        /// Gets or sets the Hour Per Week
        /// </summary>
        public decimal AdditionalNeedsPayment { get; set; }

        /// <summary>
        /// Gets or sets the Additional Needs Payment One Off
        /// </summary>
        public decimal AdditionalNeedsPaymentOneOff { get; set; }
    }
}
