using BaseApi.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.V1.Infrastructure.SeedConfiguration
{
    public class TermTimeConsiderationOptionsSeed : IEntityTypeConfiguration<TermTimeConsiderationOption>
    {
        public void Configure(EntityTypeBuilder<TermTimeConsiderationOption> builder)
        {
            builder.HasData(
                new TermTimeConsiderationOption { OptionId = 1, OptionName = "N/A" },
                new TermTimeConsiderationOption { OptionId = 2, OptionName = "Term Time" },
                new TermTimeConsiderationOption { OptionId = 3, OptionName = "Holiday" });
        }
    }
}
