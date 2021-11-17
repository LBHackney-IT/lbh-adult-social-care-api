using System;
using LBH.AdultSocialCare.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Data.SeedConfiguration
{
    public class ProvisionalCareChargeAmountSeed : IEntityTypeConfiguration<ProvisionalCareChargeAmount>
    {
        public void Configure(EntityTypeBuilder<ProvisionalCareChargeAmount> builder)
        {
            var startDate = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var endDate = new DateTime(2020, 12, 31, 0, 0, 0, DateTimeKind.Utc);

            builder.HasData(new ProvisionalCareChargeAmount
            {
                Id = 1,
                StartDate = startDate,
                EndDate = endDate,
                AgeFrom = 18,
                AgeTo = 24,
                Amount = 68.95M
            }, new ProvisionalCareChargeAmount
            {
                Id = 2,
                StartDate = startDate,
                EndDate = endDate,
                AgeFrom = 25,
                AgeTo = 59,
                Amount = 84.40M
            }, new ProvisionalCareChargeAmount
            {
                Id = 3,
                StartDate = startDate,
                EndDate = endDate,
                AgeFrom = 60,
                AgeTo = null,
                Amount = 148.45M
            }, new ProvisionalCareChargeAmount
            {
                Id = 4,
                StartDate = startDate.AddYears(1),
                EndDate = endDate.AddYears(1),
                AgeFrom = 18,
                AgeTo = 24,
                Amount = 69.40M
            }, new ProvisionalCareChargeAmount
            {
                Id = 5,
                StartDate = startDate.AddYears(1),
                EndDate = endDate.AddYears(1),
                AgeFrom = 25,
                AgeTo = 59,
                Amount = 84.90M
            }, new ProvisionalCareChargeAmount
            {
                Id = 6,
                StartDate = startDate.AddYears(1),
                EndDate = endDate.AddYears(1),
                AgeFrom = 60,
                AgeTo = null,
                Amount = 152.20M
            });
        }
    }
}
