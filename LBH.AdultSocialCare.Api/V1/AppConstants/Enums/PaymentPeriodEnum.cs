using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum PaymentPeriodEnum
    {
        [Display(Name = "Weekly")]
        Weekly = 1,

        [Display(Name = "One-off")]
        OneOff = 2,

        [Display(Name = "Fixed")]
        FixedPeriod = 3
    }
}
