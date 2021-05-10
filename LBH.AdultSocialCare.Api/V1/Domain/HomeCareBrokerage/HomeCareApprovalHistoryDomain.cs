using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerage
{
    public class HomeCareApprovalHistoryDomain
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        public Guid HomeCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Approved Date
        /// </summary>
        public DateTimeOffset ApprovedDate { get; set; }

        /// <summary>
        /// Gets or sets the User Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the Log Text
        /// </summary>
        public string LogText { get; set; }
    }
}
