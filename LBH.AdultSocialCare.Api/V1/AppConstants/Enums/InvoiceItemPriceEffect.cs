using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum InvoiceItemPriceEffect
    {
        [Display(Name = "None")] None = 1,
        [Display(Name = "Add")] Add = 2,
        [Display(Name = "Subtract")] Subtract = 3
    }
}
