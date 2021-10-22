using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum HistoryStatus
    {
        [Display(Description = "Package Created")]
        NewPackage = 1,

        [Display(Description = "Package Submitted for approval")]
        SubmittedForApproval = 2,

        [Display(Description = "Further information requested by")]
        RequestMoreInformation = 3,

        [Display(Description = "Care package Approved by")]
        PackageApproved = 4,

        [Display(Description = "Care Package Brokered by")]
        PackageBrokered = 5,

        [Display(Description = "Care Package Approved for Commercial by")]
        ApprovedForCommercial = 6,

        [Display(Name = "Clarifying Commercials requested by")]
        ClarifyingCommercials = 7,

        [Display(Name = "Care Package Approved for Brokerage by")]
        ApprovedForBrokerage = 8,

        [Display(Name = "PO Issued by")]
        PackagePoIssued = 9,

        [Display(Name = "Care Package rejected by")]
        Rejected = 10,

        [Display(Name = "Package Ended")]
        BrokeredEnded = 11,

        [Display(Name = "Care Package cancelled by")]
        Cancelled = 12
    }
}
