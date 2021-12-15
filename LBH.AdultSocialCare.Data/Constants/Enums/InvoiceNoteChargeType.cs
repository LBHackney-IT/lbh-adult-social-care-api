using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum InvoiceNoteChargeType
    {
        [Display(Name = "OverCharge")] OverCharge = 1,
        [Display(Name = "UnderCharge")] UnderCharge = 2
    }
}
