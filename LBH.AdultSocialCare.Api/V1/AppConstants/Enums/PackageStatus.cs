using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    // TODO: VK: There is a discrepancy between statuses in constants and DB - what is actual?
    public enum PackageStatus
    {
        [Display(Name = "Draft")]
        Draft = 1,

        [Display(Name = "New")]
        New = 2,

        [Display(Name = "Submitted for Approval")]
        SubmittedForApproval = 3,

        [Display(Name = "Reject Package")]
        Rejected = 4,

        [Display(Name = "Clarification Needed")]
        ClarificationNeeded = 5,

        [Display(Name = "Approved")]
        Approved = 6
    }
}
