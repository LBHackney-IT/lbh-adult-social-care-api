using System.ComponentModel.DataAnnotations.Schema;
using LBH.AdultSocialCare.Data.Constants.Enums;

namespace LBH.AdultSocialCare.Data.Entities.CarePackages
{
    public class CarePackageSchedulingOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public PackageScheduling Id { get; set; }

        public string OptionName { get; set; }
        public string OptionPeriod { get; set; }
    }
}
