using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims
{
    public class ReclaimCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReclaimCategoryId { get; set; }

        public string ReclaimCategoryName { get; set; }
    }
}
