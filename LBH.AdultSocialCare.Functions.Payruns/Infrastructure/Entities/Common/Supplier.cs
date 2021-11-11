using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities.Common
{
    public class Supplier : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string CedarName { get; set; }
        public string CedarReferenceNumber { get; set; }
        public int? CedarId { get; set; }
    }
}
