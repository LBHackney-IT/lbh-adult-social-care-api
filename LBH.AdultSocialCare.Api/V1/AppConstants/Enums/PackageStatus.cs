using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    // TODO: VK: There is a discrepancy between statuses in constants and DB - what is actual?
    public enum PackageStatus
    {
        [Display(Name = "New Package")]
        New = 1,

        [Display(Name = "Submitted for Approval")]
        SubmittedForApproval = 2,

        [Display(Name = "Contents Approved")]
        ContentsApproved = 3,

        [Display(Name = "Reject Package")]
        Rejected = 4,

        [Display(Name = "Clarification Needed")]
        ClarificationNeeded = 5,

        [Display(Name = "Brokerage - New")]
        BrokerageNew = 6,

        [Display(Name = "Brokerage - Assigned")]
        BrokerageAssigned = 7,

        [Display(Name = "Brokerage - Querying")]
        BrokerageQuerying = 8,

        [Display(Name = "Brokerage - Supplier Sourced")]
        BrokerageSupplierSourced = 9,

        [Display(Name = "Brokerage - Pricing Agreed")]
        BrokeragePricingAgreed = 10,

        [Display(Name = "Brokerage - Submitted for Approval")]
        BrokerageSubmittedForApproval = 11,

        [Display(Name = "Commercials Approved")]
        CommercialsApproved = 12,

        [Display(Name = "Package Commercials - Rejected")]
        BrokeredDealRejected = 13,

        [Display(Name = "Clarifying Commercials")]
        ClaryfyingCommercials = 14,

        [Display(Name = "Package Contracted")]
        Contracted = 15
    }
}
