using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Functions.Payruns.Enums
{
    public enum RolesEnum
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
        Broker = 4,

        [Description("d7cb6746-1211-4cc2-9244-f4faaef25089")]
        [Display(Name = "Approver")]
        Approver = 5,

        [Description("74b93ac7-1778-485d-a482-d76893f31aff")]
        [Display(Name = "Finance")]
        Finance = 6,

        [Description("80f1ea68-9335-4efe-b247-7aa58cc45af0")]
        [Display(Name = "User")]
        User = 7,

        [Description("1e958e66-b2a3-4e9d-9806-c5ca8bafda5d")]
        [Display(Name = "Broker Manager")]
        BrokerManager = 8,

        [Description("1f0bea0c-9f9a-4ef1-b911-83e2113dd503")]
        [Display(Name = "Broker Assistant")]
        BrokerAssistant = 9
    }
}
