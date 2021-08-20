using System;

namespace LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare
{
    public class ResidentialCareApproveBrokeredDomain
    {
        /// <summary>
        /// Gets or sets the Residential Care package
        /// </summary>
        public ResidentialCarePackageDomain ResidentialCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Cost Of Care
        /// </summary>
        public decimal CostOfCare { get; set; }

        /// <summary>
        /// Gets or sets the Additional Needs Cost
        /// </summary>
        public decimal CostOfAdditionalNeeds { get; set; }

        /// <summary>
        /// Gets or sets the Total Per Week
        /// </summary>
        public decimal TotalPerWeek { get; set; }

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
