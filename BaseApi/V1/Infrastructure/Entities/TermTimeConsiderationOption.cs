using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApi.V1.Infrastructure.Entities
{
    public class TermTimeConsiderationOption
    {
        [Key]
        [Column("OptionId")]
        public int OptionId { get; set; }
        public string OptionName { get; set; } // N/A, Term Time, Holiday
    }
}
