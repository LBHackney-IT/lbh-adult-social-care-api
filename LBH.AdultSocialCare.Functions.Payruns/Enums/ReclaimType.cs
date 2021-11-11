using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Functions.Payruns.Enums
{
    public enum ReclaimType
    {
        [Display(Name = "Funded Nursing Care")]
        Fnc = 1,

        [Display(Name = "Care Charge")]
        CareCharge = 2
    }
}
