using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{

    public class TermTimeConsiderationOption
    {

        [Key]
        [Column("OptionId")]
        public int OptionId { get; set; }

        // N/A, Term Time, Holiday
        public string OptionName { get; set; }

    }

}
