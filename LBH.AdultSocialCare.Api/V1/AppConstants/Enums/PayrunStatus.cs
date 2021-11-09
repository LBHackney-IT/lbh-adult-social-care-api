using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum PayrunStatus
    {
        [Display(Name = "Draft")]
        Draft = 1,

        [Display(Name = "In progress")]
        InProgress = 2,

        [Display(Name = "Ready For Review")]
        ReadyForReview = 3,

        [Display(Name = "Waiting for Approval")]
        WaitingForApproval = 4,

        [Display(Name = "Approved")]
        Approved = 5,

        [Display(Name = "Rejected")]
        Rejected = 6,

        [Display(Name = "Paid")]
        Paid = 7,

        [Display(Name = "Paid With Holds")]
        PaidWithHolds = 8,
    }
}
