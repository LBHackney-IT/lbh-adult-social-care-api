using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Domain.HomeCareDomains
{

    public class HomeCarePackageSlotDomain
    {

        /// <summary>
        /// Gets or sets the primary in minutes.
        /// </summary>
        public int PrimaryInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the secondary in minutes.
        /// </summary>
        public int SecondaryInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Shift Id
        /// </summary>
        public int TimeSlotShiftId { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Shift
        /// </summary>
        public TimeSlotShifts TimeSlotShift { get; set; }

        /// <summary>
        /// Gets or sets the day identifier.
        /// </summary>
        public int DayId { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the What Should Be Done
        /// </summary>
        public string WhatShouldBeDone { get; set; }

        /// <summary>
        /// Gets or sets the Service Id
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        public string Service { get; set; }

    }

}
