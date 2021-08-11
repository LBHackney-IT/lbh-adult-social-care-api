using System;

namespace LBH.AdultSocialCare.Api.V1.Boundary.Request
{

    public class TimeSlotShiftsRequest
    {

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Type Name
        /// </summary>
        public string TimeSlotShiftName { get; set; }

        /// <summary>
        /// Gets or sets the time slot time label.
        /// </summary>
        public string TimeSlotTimeLabel { get; set; }

        /// <summary>
        /// Gets or sets the Date Created
        /// </summary>
        public DateTimeOffset? DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the Date Updated
        /// </summary>
        public DateTimeOffset? DateUpdated { get; set; }

    }

}
