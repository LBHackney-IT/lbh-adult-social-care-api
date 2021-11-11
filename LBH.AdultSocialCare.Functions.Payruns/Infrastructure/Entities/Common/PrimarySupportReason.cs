using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common
{
    public class PrimarySupportReason
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PrimarySupportReasonId { get; set; }

        public string PrimarySupportReasonName { get; set; }

        public string CederBudgetCode { get; set; }
    }
}
