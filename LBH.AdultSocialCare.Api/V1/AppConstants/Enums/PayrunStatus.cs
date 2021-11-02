using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum PayrunStatus
    {
        [Display(Name = "Draft")]
        Draft = 1,

        [Display(Name = "In progress")]
        InProgress = 2,

        [Display(Name = "Waiting for Approval")]
        WaitingForApproval = 3,

        [Display(Name = "Approved")]
        Approved = 4,

        [Display(Name = "Paid")]
        Paid = 5,

        [Display(Name = "Hold")]
        Hold = 6,

        [Display(Name = "Rejected")]
        Rejected = 7
    }
}
