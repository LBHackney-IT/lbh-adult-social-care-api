using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum ReclaimStatus
    {
        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Ended")]
        Ended = 2,

        [Display(Name = "Cancelled")]
        Cancelled = 3,

        [Display(Name = "Pending")]
        Pending = 4
    }
}
