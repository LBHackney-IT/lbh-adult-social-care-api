using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class FundedNursingCareCollector
    {
        [Key] public int Id { get; set; }
        public string OptionName { get; set; }
        public string OptionInvoiceName { get; set; }
        public int ClaimedBy { get; set; }
        [ForeignKey(nameof(ClaimedBy))] public PackageCostClaimer PackageCostClaimer { get; set; }
    }
}
