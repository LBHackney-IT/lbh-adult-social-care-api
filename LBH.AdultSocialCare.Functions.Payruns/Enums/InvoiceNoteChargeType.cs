using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Functions.Payruns.Enums
{
    public enum InvoiceNoteChargeType
    {
        [Display(Name = "OverCharge")] OverCharge = 1,
        [Display(Name = "UnderCharge")] UnderCharge = 2
    }
}
