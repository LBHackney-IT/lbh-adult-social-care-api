using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum HistoryStatus
    {
        [Display(Name = "Package Created")]
        NewPackage = 1,

        [Display(Name = "Package Submitted for approval")]
        SubmittedForApproval = 2,

        [Display(Name = "Further information requested")]
        RequestMoreInformation = 3,

        [Display(Name = "Care package Approved by")]
        PackageApproved = 4,

        [Display(Name = "Care Package Brokered by")]
        PackageBrokered = 5,

        [Display(Name = "Care Package Approved for Commercial")]
        ApprovedForCommercial = 6,

        [Display(Name = "Clarifying Commercials requested")]
        ClarifyingCommercials = 7,

        [Display(Name = "Care Package Approved for Brokerage")]
        ApprovedForBrokerage = 8,

        [Display(Name = "PO Issued")]
        PackagePoIssued = 9,

        [Display(Name = "Care Package declined")]
        Declined = 10,

        [Display(Name = "Package Ended")]
        BrokeredEnded = 11,

        [Display(Name = "Care Package cancelled")]
        Cancelled = 12,

        [Display(Name = "Package Information")]
        PackageInformation = 13
    }
}
