using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class FncCollectorsSeed : IEntityTypeConfiguration<FncCollector>
    {
        public void Configure(EntityTypeBuilder<FncCollector> builder)
        {
            builder.HasData(
                new FncCollector
                {
                    Id = 1,
                    OptionName = "Supplier",
                    OptionInvoiceName = "FNC Claimed By Supplier",
                    ClaimedBy = PackageCostClaimersConstants.Supplier
                },
                new FncCollector
                {
                    Id = 2,
                    OptionName = "Hackney",
                    OptionInvoiceName = "Funded Nursing Care",
                    ClaimedBy = PackageCostClaimersConstants.Hackney
                });
        }
    }
}
