using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum ReclaimType
    {
        [Display(Name = "Funded Nursing Care")]
        Fnc = 1,

        [Display(Name = "Care Charge")]
        CareCharge = 2
    }
}
