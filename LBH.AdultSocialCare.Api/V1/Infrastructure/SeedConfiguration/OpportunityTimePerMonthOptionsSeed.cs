using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class OpportunityTimePerMonthOptionsSeed : IEntityTypeConfiguration<OpportunityTimePerMonthOption>
    {
        public void Configure(EntityTypeBuilder<OpportunityTimePerMonthOption> builder)
        {
            builder.HasData(
                new OpportunityTimePerMonthOption { OpportunityTimePerMonthOptionId = 1, OptionName = "Daily" },
                new OpportunityTimePerMonthOption { OpportunityTimePerMonthOptionId = 2, OptionName = "Weekly" },
                new OpportunityTimePerMonthOption { OpportunityTimePerMonthOptionId = 3, OptionName = "Monthly" }
            );
        }
    }
}
