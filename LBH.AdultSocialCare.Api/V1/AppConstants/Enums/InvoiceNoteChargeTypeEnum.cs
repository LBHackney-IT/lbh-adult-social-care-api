using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum InvoiceNoteChargeTypeEnum
    {
        [Display(Name = "OverCharge")] OverCharge = 1,
        [Display(Name = "UnderCharge")] UnderCharge = 2
    }
}
