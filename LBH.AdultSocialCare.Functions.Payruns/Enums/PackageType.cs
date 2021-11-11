using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Functions.Payruns.Enums
{
    public enum PackageType
    {
        // [Display(Name = "Home Care Package")]
        // HomeCare = 1,

        [Display(Name = "Residential Care Package")]
        ResidentialCare = 2,

        // [Display(Name = "Day Care Package")]
        // DayCare = 3,

        [Display(Name = "Nursing Care Package")]
        NursingCare = 4
    }
}
