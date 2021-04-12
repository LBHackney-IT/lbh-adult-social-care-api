using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class ResidentialCarePackage
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Client Id
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Clients
        /// </summary>
        [ForeignKey(nameof(ClientId))]
        public Clients Clients { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset? DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the Status Id
        /// </summary>
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the Status Object
        /// </summary>
        public Status Status { get; set; }
    }
}
