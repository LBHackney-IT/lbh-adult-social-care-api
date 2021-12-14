using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
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
