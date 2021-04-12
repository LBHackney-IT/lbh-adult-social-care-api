using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Response
{
    public class TimeSlotShiftsResponse
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Type Name
        /// </summary>
        public string TimeSlotShiftName { get; set; }

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
    }
}
