using System;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Data.SeedConfiguration
{
    public class CarePackageSchedulingOptionsSeed : IEntityTypeConfiguration<CarePackageSchedulingOption>
    {
        public void Configure(EntityTypeBuilder<CarePackageSchedulingOption> builder)
        {
            var packageSchedulingOptions = Enum.GetValues(typeof(PackageScheduling))
                .OfType<PackageScheduling>()
                .Select(x =>
                    new CarePackageSchedulingOption()
                    {
                        Id = x,
                        OptionName = x.GetDisplayName(),
                        OptionPeriod = x.ToDescription()
                    })
                .ToArray();
            builder.HasData(packageSchedulingOptions);
        }
    }
}
