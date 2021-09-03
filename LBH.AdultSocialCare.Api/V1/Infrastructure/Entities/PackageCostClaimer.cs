using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities
{
    public class PackageCostClaimer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
