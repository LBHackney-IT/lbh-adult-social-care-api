using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class FundedNursingCarePriceSeed : IEntityTypeConfiguration<FundedNursingCarePrice>
    {
        public void Configure(EntityTypeBuilder<FundedNursingCarePrice> builder)
        {
            builder.HasData(
                new FundedNursingCarePrice
                {
                    Id = 1,
                    PricePerWeek = 187.6m,
                    ActiveFrom = new DateTimeOffset(new DateTime(2019, 4, 1, 0, 0, 0, DateTimeKind.Utc)),
                    ActiveTo = new DateTimeOffset(new DateTime(2020, 4, 1, 0, 0, 0, DateTimeKind.Utc))
                },
                new FundedNursingCarePrice
                {
                    Id = 2,
                    PricePerWeek = 187.6m,
                    ActiveFrom = new DateTimeOffset(new DateTime(2020, 4, 1, 0, 0, 0, DateTimeKind.Utc)),
                    ActiveTo = new DateTimeOffset(new DateTime(2021, 4, 1, 0, 0, 0, DateTimeKind.Utc))
                },
                new FundedNursingCarePrice
                {
                    Id = 3,
                    PricePerWeek = 187.6m,
                    ActiveFrom = new DateTimeOffset(new DateTime(2021, 4, 1, 0, 0, 0, DateTimeKind.Utc)),
                    ActiveTo = new DateTimeOffset(new DateTime(2022, 4, 1, 0, 0, 0, DateTimeKind.Utc))
                });
        }
    }
}
