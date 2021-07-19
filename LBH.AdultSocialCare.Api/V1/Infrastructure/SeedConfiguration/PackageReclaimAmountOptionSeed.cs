using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageReclaimAmountOptionSeed : IEntityTypeConfiguration<ReclaimAmountOption>
    {
        public void Configure(EntityTypeBuilder<ReclaimAmountOption> builder)
        {
            builder.HasData(new ReclaimAmountOption
            {
                AmountOptionId = 1,
                AmountOptionName = "Percentage"
            }, new ReclaimAmountOption
            {
                AmountOptionId = 2,
                AmountOptionName = "Fixed amount - one off"
            }, new ReclaimAmountOption
            {
                AmountOptionId = 3,
                AmountOptionName = "Fixed amount - weekly"
            });
        }
    }
}
