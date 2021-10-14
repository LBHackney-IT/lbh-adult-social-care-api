using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common
{
    public class ProvisionalCareChargeAmount
    {
        [Key] public int Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public int AgeFrom { get; set; }
        public int? AgeTo { get; set; }
        [Column(TypeName = "decimal(13, 2)")] public decimal Amount { get; set; }
    }
}
