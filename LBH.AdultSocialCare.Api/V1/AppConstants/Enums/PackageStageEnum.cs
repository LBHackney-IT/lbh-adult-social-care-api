using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    // TODO: VK: There is a discrepancy between stages in constants and DB - what is actual?
    public enum PackageStageEnum
    {
        [Display(Name = "New")]
        New = 1,

        [Display(Name = "Assigned")]
        Assigned = 2,

        [Display(Name = "Querying")]
        Querying = 3,

        [Display(Name = "Supplier sourced")]
        SupplierSourced = 4,

        [Display(Name = "Pricing agreed")]
        PricingAgreed = 5,

        [Display(Name = "Submitted for Approval")]
        SubmittedForApproval = 6
    }
}
