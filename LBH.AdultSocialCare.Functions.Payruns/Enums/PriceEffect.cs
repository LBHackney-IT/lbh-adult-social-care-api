using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Functions.Payruns.Enums
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
