using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageCostClaimersSeed : IEntityTypeConfiguration<PackageCostClaimer>
    {
        public void Configure(EntityTypeBuilder<PackageCostClaimer> builder)
        {
            builder.HasData(
                new PackageCostClaimer
                {
                    Id = PackageCostClaimersConstants.Supplier,
                    Name = "Supplier"
                },
                new PackageCostClaimer
                {
                    Id = PackageCostClaimersConstants.Hackney,
                    Name = "Hackney"
                });
        }
    }
}
