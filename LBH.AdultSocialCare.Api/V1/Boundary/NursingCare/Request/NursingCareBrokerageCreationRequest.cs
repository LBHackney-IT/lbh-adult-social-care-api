using System;
using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Api.V1.Validations;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Request
{
    public class NursingCareBrokerageCreationRequest
    {
        /// <summary>
        /// Gets or sets the Nursing Care Package Id
        /// </summary>
        [Required, GuidNotEmpty] public Guid NursingCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Supplier Id
        /// </summary>
        [Required] public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Stage Id
        /// </summary>
        [Required] public int? StageId { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset? StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Core Per Week
        /// </summary>
        [Required] public decimal? NursingCore { get; set; }

        /// <summary>
        /// Gets or sets the Hour Per Week
        /// </summary>
        [Required] public decimal? AdditionalNeedsPayment { get; set; }

        /// <summary>
        /// Gets or sets the Additional Needs Payment One Off
        /// </summary>
        [Required] public decimal? AdditionalNeedsPaymentOneOff { get; set; }

        public int FundedNursingCareCollectorId { get; set; }
    }
}