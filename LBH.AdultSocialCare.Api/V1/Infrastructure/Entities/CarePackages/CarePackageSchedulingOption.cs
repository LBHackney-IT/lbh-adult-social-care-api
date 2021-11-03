using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages
{
    public class CarePackageSchedulingOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public PackageScheduling Id { get; set; }

        public string OptionName { get; set; }
        public string OptionPeriod { get; set; }
    }
}
