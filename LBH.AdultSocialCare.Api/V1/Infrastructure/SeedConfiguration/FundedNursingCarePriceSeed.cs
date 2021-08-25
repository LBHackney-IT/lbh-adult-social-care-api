using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                    ActiveFrom = new DateTimeOffset(new DateTime(2021, 4, 1, 0, 0, 0, DateTimeKind.Utc))
                });
        }
    }
}
