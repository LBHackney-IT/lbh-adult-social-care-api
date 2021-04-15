using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain
{
    public class NursingCarePackageDomain
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
        /// Gets or sets the Clients
        /// </summary>
        public Clients Clients { get; set; }

        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the End Date
        /// </summary>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the Is Interim
        /// </summary>
        public bool IsInterim { get; set; }

        /// <summary>
        /// Gets or sets the Is Expected Stay Over 8Weeks
        /// </summary>
        public bool IsUnder8Weeks { get; set; }

        /// <summary>
        /// Gets or sets the Is Expected Stay Over 52Weeks
        /// </summary>
        public bool IsUnder52Weeks { get; set; }

        /// <summary>
        /// Gets or sets the Is Long Stay
        /// </summary>
        public bool IsLongStay { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Nursing Home
        /// </summary>
        public string TypeOfNursingHome { get; set; }

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
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTimeOffset? DateUpdated { get; set; }

        /// <summary>
        /// Gets or sets the Status Id
        /// </summary>
        public Guid StatusId { get; set; }

        /// <summary>
        /// Gets or sets the Status Object
        /// </summary>
        public PackageStatus Status { get; set; }
    }
}
