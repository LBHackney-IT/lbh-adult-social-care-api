using LBH.AdultSocialCare.Api.V1.Domain;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Response
{
    public class NursingCarePackageResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        public Guid? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Clients
        /// </summary>
        public Clients Clients { get; set; }

        public bool IsFixedPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is respite care.</summary>
        public bool IsRespiteCare { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is discharge package.</summary>
        public bool IsDischargePackage { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is this an immediate service.</summary>
        public bool IsThisAnImmediateService { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is this user under S117.</summary>
        public bool IsThisUserUnderS117 { get; set; }

        public int? TypeOfStayId { get; set; }

        public NursingCareTypeOfStayOption TypeOfStayOption { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Care Home Id
        /// </summary>
        public int? TypeOfNursingCareHomeId { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Care Home
        /// </summary>
        public TypeOfNursingCareHome TypeOfCareHome { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int? UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTimeOffset? DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the Status Id
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the Status Object
        /// </summary>
        public PackageStatus Status { get; set; }


        /// <summary>
        /// Gets or sets the NursingCareAdditionalNeeds
        /// </summary>
        public virtual ICollection<NursingCareAdditionalNeeds> NursingCareAdditionalNeeds { get; set; }
    }
}
