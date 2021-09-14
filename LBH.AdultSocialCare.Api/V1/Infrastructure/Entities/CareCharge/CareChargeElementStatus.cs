using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge
{
    public class CareChargeElementStatus
    {
        [Key]
        public int Id { get; set; }

        public string StatusName { get; set; }
    }
}
