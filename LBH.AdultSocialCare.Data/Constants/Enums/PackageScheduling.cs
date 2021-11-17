using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Data.Constants.Enums
{
    public enum PackageScheduling
    {
        [Description("6 weeks and under")]
        [Display(Name = "Interim or immediate service")]
        Interim = 1,

        [Description("Expected 52 weeks or under")]
        [Display(Name = "Temporary")]
        Temporary = 2,

        [Description("52+ weeks")]
        [Display(Name = "Long term")]
        LongTerm = 3
    }
}
