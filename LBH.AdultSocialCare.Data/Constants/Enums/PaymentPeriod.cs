using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum PaymentPeriod
    {
        [Display(Name = "Hourly")]
        Hourly = 1,

        [Display(Name = "Weekly")]
        Weekly = 2,

        [Display(Name = "One-off")]
        OneOff = 3,

        [Display(Name = "Fixed")]
        Fixed = 4
    }
}