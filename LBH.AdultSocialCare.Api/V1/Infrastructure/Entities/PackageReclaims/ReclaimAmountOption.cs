using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims
{
    public class ReclaimAmountOption
    {
        [Key]
        public int AmountOptionId { get; set; }

        // Percentage, Fixed Amount - one off, Fixed amount weekly
        public string AmountOptionName { get; set; }
    }
}
