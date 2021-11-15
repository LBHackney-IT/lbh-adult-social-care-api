using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Functions.Payruns.Enums
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
        Accepted = 5

        // TODO TBD
    }
}