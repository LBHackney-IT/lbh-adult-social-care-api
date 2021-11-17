using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum PriceEffect
    {
        [Display(Name = "None")]
        None = 1,

        [Display(Name = "Add")]
        Add = 2,

        [Display(Name = "Subtract")]
        Subtract = 3
    }
}
