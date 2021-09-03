using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class FundedNursingCarePrice
    {
        [Key] public int Id { get; set; }
        [Required] [Column(TypeName = "decimal(13, 2)")] public decimal PricePerWeek { get; set; }
        [Required] public DateTimeOffset ActiveFrom { get; set; }
        [Required] public DateTimeOffset ActiveTo { get; set; }
    }
}
