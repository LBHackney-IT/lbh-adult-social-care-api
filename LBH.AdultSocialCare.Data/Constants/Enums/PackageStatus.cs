using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    // TODO: VK: There is a discrepancy between statuses in constants and DB - what is actual?
    public enum PackageStatus
    {
        [Display(Name = "New")]
        New = 1,

        [Display(Name = "In Progress")]
        InProgress = 2,

        [Display(Name = "Waiting for approval")]
        SubmittedForApproval = 3,

        [Display(Name = "Approved")]
        Approved = 4,

        [Display(Name = "Not Approved")]
        NotApproved = 5,

        [Display(Name = "Ended")]
        Ended = 6,

        [Display(Name = "Cancelled")]
        Cancelled = 7,

        [Display(Name = "Rejected")]
        Rejected = 8,
    }
}
