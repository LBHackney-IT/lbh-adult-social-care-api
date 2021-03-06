using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum PayrunStatus
    {
        [Display(Name = "Draft")]
        Draft = 1,

        [Display(Name = "In progress")]
        InProgress = 2,

        [Display(Name = "Ready for review")]
        WaitingForReview = 3,

        [Display(Name = "Waiting for Approval")]
        WaitingForApproval = 4,

        [Display(Name = "Approved")]
        Approved = 5,

        [Display(Name = "Paid")]
        Paid = 6,

        [Display(Name = "Paid with hold")]
        PaidWithHold = 7,

        [Display(Name = "Archived")]
        Archived = 8
    }
}
