using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Functions.Payruns.Infrastructure.Entities
{
    public class Supplier
    {
        //TODO: VK: Remove
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
    }
}
