using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class OpportunityTimePerMonthOption
    {
        [Key]
        [Column("OpportunityTimePerMonthOptionId")]
        public int OpportunityTimePerMonthOptionId { get; set; }

        // Daily, Weekly, Monthly
        public string OptionName { get; set; }
    }
}
