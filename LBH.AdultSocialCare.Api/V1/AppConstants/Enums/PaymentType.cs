using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum PaymentType
    {
        [Display(Name = "Weekly")]
        WeeklyCost = 1,

        [Display(Name = "One-off")]
        OneOff = 2,

        [Display(Name = "Fixed period")]
        FixedPeriod = 3
    }
}
