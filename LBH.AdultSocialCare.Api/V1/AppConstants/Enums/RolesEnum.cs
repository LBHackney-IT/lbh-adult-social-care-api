using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.AppConstants.Enums
{
    public enum RolesEnum : int
    {
        [Description("7335e791-1d08-437a-974e-809944d29bc6")]
        [Display(Name = "Super Administrator")]
        SuperAdministrator = 1,

        [Description("66e830f6-ea42-44ad-beed-bbede0ff69df")]
        [Display(Name = "Administrator")]
        Administrator = 2,

        [Description("4defe6f2-09cf-43f2-8c1f-f4cad04a582d")]
        [Display(Name = "Social Worker")]
        SocialWorker = 3,

        [Description("97c46919-fd10-47f1-bcb9-fa6b513c4c83")]
        [Display(Name = "Broker")]
        Broker = 4
    }
}
