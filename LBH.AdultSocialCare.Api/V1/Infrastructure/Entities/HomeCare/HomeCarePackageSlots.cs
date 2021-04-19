using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare
{

    public class HomeCarePackageSlots
    {

        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        [ForeignKey(nameof(HomeCarePackageId))]
        public Guid HomeCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Service Id
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the Services
        /// </summary>
        [ForeignKey(nameof(ServiceId))]
        public HomeCareServiceType Services { get; set; }

        /// <summary>
        /// Gets or sets the Primary Carer
        /// </summary>
        public int PrimaryInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the Secondary Carer
        /// </summary>
        public int SecondaryInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the What Should Be Done
        /// </summary>
        public string WhatShouldBeDone { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Shift Id
        /// </summary>
        public int TimeSlotShiftId { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Shift
        /// </summary>
        [ForeignKey(nameof(TimeSlotShiftId))]
        public TimeSlotShifts TimeSlotShift { get; set; }

        /// <summary>
        /// Gets or sets the day of the week identifier.
        /// </summary>
        public int DayId { get; set; }

        /// <summary>
        /// Gets the day of week.
        /// </summary>
        [NotMapped]
        public DayOfWeek DayOfWeek => (DayOfWeek) DayId;

    }

}
