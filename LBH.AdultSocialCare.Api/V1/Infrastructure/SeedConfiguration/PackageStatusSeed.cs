using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
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
