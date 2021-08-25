using System;
using System.ComponentModel.DataAnnotations;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare
{
    public class FundedNursingCarePrice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal PricePerWeek { get; set; }

        [Required]
        public DateTimeOffset ActiveFrom { get; set; }

        public DateTimeOffset ActiveTo { get; set; }
    }
}
