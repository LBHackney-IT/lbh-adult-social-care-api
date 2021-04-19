using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class OpportunityTimesPerMonthOptionsSeed : IEntityTypeConfiguration<OpportunityTimesPerMonthOption>
    {
        public void Configure(EntityTypeBuilder<OpportunityTimesPerMonthOption> builder)
        {
            builder.HasData(
                new OpportunityTimesPerMonthOption { OpportunityTimePerMonthOptionId = 1, OptionName = "Daily" },
                new OpportunityTimesPerMonthOption { OpportunityTimePerMonthOptionId = 2, OptionName = "Weekly" },
                new OpportunityTimesPerMonthOption { OpportunityTimePerMonthOptionId = 3, OptionName = "Monthly" }
            );
        }
    }
}
