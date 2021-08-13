using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare
{
    public class TimeSlotShifts : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Time Slot Type Name
        /// </summary>
        [Required]
        public string TimeSlotShiftName { get; set; }

        /// <summary>
        /// Gets or sets the time slot time label.
        /// </summary>
        public string TimeSlotTimeLabel { get; set; }

        /// <summary>
        /// This allows us to determine if this time shift
        /// should directly correspond to just one service.
        /// </summary>
        public int? LinkedToHomeCareServiceTypeId { get; set; }

        /// <summary>
        /// This allows us to determine if this time shift
        /// should directly correspond to just one service.
        /// </summary>
        [ForeignKey(nameof(LinkedToHomeCareServiceTypeId))]
        public HomeCareServiceType HomeCareServiceType { get; set; }
    }
}
