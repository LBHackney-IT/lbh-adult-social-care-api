using BaseApi.V1.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Boundary.Response
{
    public class HomeCarePackageSlotsResponseList
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        public Guid HomeCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Service Id
        /// </summary>
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the Services
        /// </summary>
        public PackageServices Services { get; set; }

        /// <summary>
        /// Gets or sets the Primary Carer
        /// </summary>
        public string PrimaryCarer { get; set; }

        /// <summary>
        /// Gets or sets the Secondary Carer
        /// </summary>
        public string SecondaryCarer { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the What Should Be Done
        /// </summary>
        public string WhatShouldBeDone { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Slot Response
        /// </summary>
        public List<HomeCarePackageSlotResponse> HomeCarePackageSlotResponse { get; set; }
    }

    public class HomeCarePackageSlotResponse
    {
        /// <summary>
        /// Gets or sets the InMinutes
        /// </summary>
        public int InMinutes { get; set; }

        /// <summary>
        /// Gets or sets the In Hours
        /// </summary>
        public int InHours { get; set; }

        /// <summary>
        /// Gets or sets the Time
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Type Id
        /// </summary>
        public Guid TimeSlotTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Types
        /// </summary>
        public TimeSlotType TimeSlotTypes { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Shift Id
        /// </summary>
        public Guid TimeSlotShiftId { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Shift
        /// </summary>
        public TimeSlotShifts TimeSlotShift { get; set; }
    }
}
