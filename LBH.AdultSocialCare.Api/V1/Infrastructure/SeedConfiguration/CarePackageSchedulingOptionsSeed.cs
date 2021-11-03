using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
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
