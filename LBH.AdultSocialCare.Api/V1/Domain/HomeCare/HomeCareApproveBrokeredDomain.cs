namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCare
{
    public class HomeCareApproveBrokeredDomain
    {
        /// <summary>
        /// Gets or sets the Home Care package
        /// </summary>
        public HomeCarePackageDomain HomeCarePackage { get; set; }

        /// <summary>
        /// Gets or sets the Hours Per Week
        /// </summary>
        public double HoursPerWeek { get; set; }

        /// <summary>
        /// Gets or sets the Cost Of Care
        /// </summary>
        public decimal CostOfCare { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Break Down
        /// </summary>
        public HomeCarePackageBreakDownDomain HomeCarePackageBreakDown { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Elements Costing
        /// </summary>
        public HomeCarePackageElementsCostingDomain HomeCarePackageElementsCosting { get; set; }

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
