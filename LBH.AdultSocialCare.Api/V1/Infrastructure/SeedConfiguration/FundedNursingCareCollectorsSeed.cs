using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class FundedNursingCareCollectorsSeed : IEntityTypeConfiguration<FundedNursingCareCollector>
    {
        public void Configure(EntityTypeBuilder<FundedNursingCareCollector> builder)
        {
            builder.HasData(
                new FundedNursingCareCollector
                {
                    Id = 1,
                    OptionName = "Supplier",
                    OptionInvoiceName = "FNC Claimed By Supplier",
                    ClaimedBy = PackageCostClaimersConstants.Supplier
                },
                new FundedNursingCareCollector
                {
                    Id = 2,
                    OptionName = "Hackney",
                    OptionInvoiceName = "Funded Nursing Care",
                    ClaimedBy = PackageCostClaimersConstants.Hackney
                });
        }
    }
}
