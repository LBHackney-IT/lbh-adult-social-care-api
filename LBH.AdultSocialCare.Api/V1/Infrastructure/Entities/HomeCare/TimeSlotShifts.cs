using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string TimeSlotTimeLabel { get; set; }

        /// <summary>
        /// Gets or sets the Creator Id
        /// </summary>
        public int CreatorId { get; set; }

        /// <summary>
        /// Gets or sets the Updator Id
        /// </summary>
        public int UpdatorId { get; set; }

    }

}
