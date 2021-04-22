using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain
{
    public class ResidentialCarePackageDomain
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Client
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

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
        /// Gets or sets the Type Of Residential Home Id
        /// </summary>
        public int TypeOfResidentialCareHomeId { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Residential Home
        /// </summary>
        public TypeOfResidentialCareHome TypeOfResidentialCareHome { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Id
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the PackageStatuses Object
        /// </summary>
        public PackageStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the Residential Care Additional Needs
        /// </summary>
        public List<ResidentialCareAdditionalNeed> ResidentialCareAdditionalNeeds { get; set; }
    }
}
