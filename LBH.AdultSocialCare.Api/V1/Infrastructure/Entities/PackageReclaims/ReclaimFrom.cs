using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims
{
    public class ReclaimFrom
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReclaimFromId { get; set; }

        public string ReclaimFromName { get; set; }
    }
}
