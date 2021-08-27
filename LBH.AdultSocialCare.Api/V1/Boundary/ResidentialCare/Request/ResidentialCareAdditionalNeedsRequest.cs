using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.ResidentialCare.Request
{
    public class ResidentialCareAdditionalNeedsRequest
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Care Package Id
        /// </summary>
        public Guid ResidentialCarePackageId { get; set; }

        public int AdditionalNeedsPaymentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }
    }
}
