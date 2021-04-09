using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Response
{
    public class ResidentialCarePackageResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Package Id
        /// </summary>
        public Guid PackageId { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Is Respite Care
        /// </summary>
        public bool IsRespiteCare { get; set; }

        /// <summary>
        /// Gets or sets the Is Discharge Package
        /// </summary>
        public bool IsDischargePackage { get; set; }

        /// <summary>
        /// Gets or sets the Is Immediate Reenablement Package
        /// </summary>
        public bool IsImmediateReenablementPackage { get; set; }

        /// <summary>
        /// Gets or sets the Is Expected Stay Over 52Weeks
        /// </summary>
        public bool IsExpectedStayOver52Weeks { get; set; }

        /// <summary>
        /// Gets or sets the Is This User Under S117
        /// </summary>
        public bool IsThisUserUnderS117 { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string TypeOfCareHome { get; set; }

        /// <summary>
        /// Gets or sets the Weekly
        /// </summary>
        public bool Weekly { get; set; }

        /// <summary>
        /// Gets or sets the One Off
        /// </summary>
        public bool OneOff { get; set; }

        /// <summary>
        /// Gets or sets the Additional Need To Address
        /// </summary>
        public string AdditionalNeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTime? DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the Status Id
        /// </summary>
        public Guid StatusId { get; set; }
    }
}
