using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class CarePackageSchedulingOptionsSeed : IEntityTypeConfiguration<CarePackageSchedulingOption>
    {
        public void Configure(EntityTypeBuilder<CarePackageSchedulingOption> builder)
        {
            builder.HasData(
                new CarePackageSchedulingOption
                {
                    Id = PackageScheduling.Interim,
                    OptionName = PackageScheduling.Interim.GetDisplayName(),
                    OptionPeriod = PackageScheduling.Interim.ToDescription()
                },
                new CarePackageSchedulingOption
                {
                    Id = PackageScheduling.Temporary,
                    OptionName = PackageScheduling.Temporary.GetDisplayName(),
                    OptionPeriod = PackageScheduling.Temporary.ToDescription()
                },
                new CarePackageSchedulingOption
                {
                    Id = PackageScheduling.LongTerm,
                    OptionName = PackageScheduling.LongTerm.GetDisplayName(),
                    OptionPeriod = PackageScheduling.LongTerm.ToDescription()
                });
        }
    }
}
