using System;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Data.SeedConfiguration
{
    public class PackageStatusSeed : IEntityTypeConfiguration<PackageStatusOption>
    {
        public void Configure(EntityTypeBuilder<PackageStatusOption> builder)
        {
            // var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            var statusOptions = Enum.GetValues(typeof(PackageStatus))
                .OfType<PackageStatus>()
                .Select(x =>
                    new PackageStatusOption()
                    {
                        Id = (int) x,
                        StatusName = x.ToString(),
                        StatusDisplayName = x.GetDisplayName()
                    })
                .ToArray();
            builder.HasData(statusOptions);
        }
    }
}
