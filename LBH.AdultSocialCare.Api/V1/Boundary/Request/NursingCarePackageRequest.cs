using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Request
{
    public class NursingCarePackageRequest
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        [Required]
        public Guid? ClientId { get; set; }

        [Required]
        public bool IsFixedPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        [Required]
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is respite care.
        /// </summary>
        public bool IsRespiteCare { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is discharge package.
        /// </summary>
        public bool IsDischargePackage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is this an immediate service.
        /// </summary>
        public bool IsThisAnImmediateService { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is this user under S117.</summary>
        public bool IsThisUserUnderS117 { get; set; }

        [Required]
        public int? TypeOfStayId { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Care Home Id
        /// </summary>
        [Required]
        public int? TypeOfNursingCareHomeId { get; set; }

        /// <summary>
        /// Gets or sets the Status Id
        /// </summary>
        public int StatusId { get; set; }

        public List<NursingCareAdditionalNeedsRequest> NursingCareAdditionalNeeds { get; set; }
    }
}
