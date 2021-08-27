using System;
using System.Collections.Generic;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response
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

        public IEnumerable<NursingCareAdditionalNeedsCostResponse> NursingCareAdditionalNeedsCosts { get; set; }

        /// <summary>
        /// Gets or sets the package brokerage stage id.
        /// </summary>
        public int? StageId { get; set; }

        /// <summary>
        /// Gets or sets the brokerage supplier.
        /// </summary>
        public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public Guid? UpdatorId { get; set; }
    }
}
