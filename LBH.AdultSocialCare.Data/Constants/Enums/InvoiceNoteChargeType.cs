using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum InvoiceNoteChargeType
    {
        [Display(Name = "OverCharge")] OverCharge = 1,
        [Display(Name = "UnderCharge")] UnderCharge = 2
    }
}
