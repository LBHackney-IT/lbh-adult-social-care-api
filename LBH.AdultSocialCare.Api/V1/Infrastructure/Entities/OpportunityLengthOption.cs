using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class OpportunityLengthOption
    {
        [Key]
        [Column("OpportunityLengthOptionId")]
        public int OpportunityLengthOptionId { get; set; }

        // 45 minutes, 1 hour, 1 hour 15 minutes
        public string OptionName { get; set; }

        public int TimeInMinutes { get; set; }
    }
}
