using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Request
{
    public class NursingCareBrokerageCreationRequest
    {
        /// <summary>
        /// Gets or sets the Nursing Care Package Id
        /// </summary>
        public Guid NursingCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Core Per Week
        /// </summary>
        public decimal NursingCore { get; set; }

        /// <summary>
        /// Gets or sets the Hour Per Week
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
