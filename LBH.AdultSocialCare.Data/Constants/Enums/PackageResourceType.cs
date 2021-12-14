using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum PackageResourceType
    {
        [Display(Name = "Care Plan File")]
        CarePlanFile = 1,

        [Display(Name = "FNC Assessment File")]
        FncAssessmentFile = 2,

        [Display(Name = "Care Charge Assessment File")]
        CareChargeAssessmentFile = 3
    }
}
