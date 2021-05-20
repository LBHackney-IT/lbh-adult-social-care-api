using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims
{
    public class HomeCarePackageReclaimFrom
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReclaimFromId { get; set; }

        public string ReclaimFromName { get; set; }
    }
}
