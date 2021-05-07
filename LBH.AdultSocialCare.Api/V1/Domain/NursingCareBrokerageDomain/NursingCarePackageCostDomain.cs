using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomain
{
    public class NursingCarePackageCostDomain
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        public Guid NursingCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Cost Type Id
        /// </summary>
        public int CostTypeId { get; set; }

        /// <summary>
        /// Gets or sets the CostType
        /// </summary>
        public CostTypeDomain CostType { get; set; }

        /// <summary>
        /// Gets or sets the Cost Per Week
        /// </summary>
        public decimal CostPerWeek { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public Guid? CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public Guid? UpdatorId { get; set; }
    }
}
