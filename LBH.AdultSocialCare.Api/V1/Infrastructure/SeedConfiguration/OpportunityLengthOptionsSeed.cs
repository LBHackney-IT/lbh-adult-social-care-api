using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class OpportunityLengthOptionsSeed : IEntityTypeConfiguration<OpportunityLengthOption>
    {
        public void Configure(EntityTypeBuilder<OpportunityLengthOption> builder)
        {
            builder.HasData(
                new OpportunityLengthOption
                {
                    OpportunityLengthOptionId = 1,
                    OptionName = "45 minutes",
                    TimeInMinutes = 45
                },
                new OpportunityLengthOption
                {
                    OpportunityLengthOptionId = 2,
                    OptionName = "1 hour",
                    TimeInMinutes = 60
                },
                new OpportunityLengthOption
                {
                    OpportunityLengthOptionId = 3,
                    OptionName = "1 hour 15 minutes",
                    TimeInMinutes = 75
                });
        }
    }
}
