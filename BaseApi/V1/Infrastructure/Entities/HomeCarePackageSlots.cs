using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Infrastructure.Entities
{
    public class HomeCarePackageSlots
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the Home Care Package Id
        /// </summary>
        [JsonProperty("Home Care Package Id")]
        [ForeignKey(nameof(HomeCarePackageId))]
        public Guid HomeCarePackageId { get; set; }

        /// <summary>
        /// Gets or sets the Service Id
        /// </summary>
        [JsonProperty("Service Id")]
        public Guid ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the Services
        /// </summary>
        [JsonProperty("Services")]
        [ForeignKey(nameof(ServiceId))]
        public PackageServices Services { get; set; }

        /// <summary>
        /// Gets or sets the Primary Carer
        /// </summary>
        [JsonProperty("PrimaryCarer")]
        public string PrimaryCarer { get; set; }

        /// <summary>
        /// Gets or sets the Secondary Carer
        /// </summary>
        [JsonProperty("Secondary Carer")]
        public string SecondaryCarer { get; set; }

        /// <summary>
        /// Gets or sets the Need To Address
        /// </summary>
        [JsonProperty("Need To Address")]
        public string NeedToAddress { get; set; }

        /// <summary>
        /// Gets or sets the What Should Be Done
        /// </summary>
        [JsonProperty("WhatShouldBeDone")]
        public string WhatShouldBeDone { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Type Id
        /// </summary>
        [JsonProperty("Time Slot Type Id")]
        public Guid TimeSlotTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Types
        /// </summary>
        [JsonProperty("Time Slot Types")]
        [ForeignKey(nameof(TimeSlotTypeId))]
        public TimeSlotType TimeSlotTypes { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Shift Id
        /// </summary>
        [JsonProperty("Time Slot Shift Id")]
        public Guid TimeSlotShiftId { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Shift
        /// </summary>
        [JsonProperty("Time Slot Shift")]
        [ForeignKey(nameof(TimeSlotShiftId))]
        public TimeSlotShifts TimeSlotShift { get; set; }

        /// <summary>
        /// Gets or sets the InMinutes
        /// </summary>
        [JsonProperty("InMinutes")]
        public int InMinutes { get; set; }

        /// <summary>
        /// Gets or sets the In Hours
        /// </summary>
        [JsonProperty("InHours")]
        public int InHours { get; set; }

        /// <summary>
        /// Gets or sets the Time
        /// </summary>
        [JsonProperty("Time")]
        public int Time { get; set; }
    }
}
