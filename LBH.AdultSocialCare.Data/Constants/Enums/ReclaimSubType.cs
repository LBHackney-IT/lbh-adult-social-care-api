using System.ComponentModel.DataAnnotations;
using LBH.AdultSocialCare.Data.Attributes;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    [Lookup]
    public enum ReclaimSubType
    {
        [Display(Name = "Provisional Care Charge")]
        CareChargeProvisional = 1,

        [Display(Name = "Without Property 1-12 Weeks")]
        CareCharge1To12Weeks = 2,

        [Display(Name = "Without Property 13+ Weeks")]
        CareCharge13PlusWeeks = 3,

        [Display(Name = "FNC Payment")]
        FncPayment = 4,

        [Display(Name = "FNC Reclaim")]
        FncReclaim = 5
    }
}
