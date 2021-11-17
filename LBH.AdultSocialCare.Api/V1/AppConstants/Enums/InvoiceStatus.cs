using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum InvoiceStatus
    {
        [Display(Name = "Draft")]
        Draft = 1,

        [Display(Name = "Held")]
        Held = 2,

        [Display(Name = "Released")]
        Released = 3,

        [Display(Name = "Rejected")]
        Rejected = 4,

        [Display(Name = "Accepted")]
        Accepted = 5,

        [Display(Name = "ReleaseAccepted")]
        ReleaseAccepted = 6,
    }
}
