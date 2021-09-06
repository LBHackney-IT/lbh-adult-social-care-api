using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge
{
    public class ProvisionalCareChargeAmount
    {
        [Key]
        public int Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal Amount { get; set; }
    }
}
