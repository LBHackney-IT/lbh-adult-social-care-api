using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCarePackageBoundary.Response;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCareBrokerageBoundary.Response
{
    public class NursingCareBrokerageInfoResponse
    {
        /// <summary>
        /// Gets or sets the Nursing Care Brokerage Id
        /// </summary>
        public Guid NursingCareBrokerageId { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Care Package Id
        /// </summary>
        public Guid NursingCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Care Package
        /// </summary>
        public NursingCarePackageResponse NursingCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Core Per Week
        /// </summary>
        public decimal NursingCore { get; set; }

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
