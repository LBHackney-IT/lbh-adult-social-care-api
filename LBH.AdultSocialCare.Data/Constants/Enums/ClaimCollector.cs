using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum ClaimCollector
    {
        [Display(Name = "Supplier")]
        Supplier = 1,

        [Display(Name = "Hackney")]
        Hackney = 2
    }
}
