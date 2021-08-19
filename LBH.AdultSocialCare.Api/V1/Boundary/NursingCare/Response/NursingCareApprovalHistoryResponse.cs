using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.NursingCare.Response
{
    public class NursingCareApprovalHistoryResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Nursing Care Package Id
        /// </summary>
        public Guid NursingCarePackageId { get; set; }

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

        public string LogSubText { get; set; }
        public string CreatorRole { get; set; }
    }
}
