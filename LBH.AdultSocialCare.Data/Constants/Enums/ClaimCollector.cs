using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum ClaimCollector
    {
        [Display(Name = "Supplier")]
        Supplier = 1,

        [Display(Name = "Hackney")]
        Hackney = 2
    }
}
