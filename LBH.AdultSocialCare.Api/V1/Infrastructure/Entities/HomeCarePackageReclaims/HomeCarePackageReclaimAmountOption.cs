using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims
{
    public class HomeCarePackageReclaimAmountOption 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AmountOptionId { get; set; }

        // Percentage, Fixed Amount - one off, Fixed amount weekly
        public string AmountOptionName { get; set; }
    }
}
