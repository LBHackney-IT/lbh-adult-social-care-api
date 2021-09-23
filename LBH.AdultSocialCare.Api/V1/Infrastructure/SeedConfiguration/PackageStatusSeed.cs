using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageStatusSeed : IEntityTypeConfiguration<PackageStatusOption>
    {
        public void Configure(EntityTypeBuilder<PackageStatusOption> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new PackageStatusOption
            {
                Id = (int) AppConstants.Enums.PackageStatus.Draft,
                StatusName = nameof(AppConstants.Enums.PackageStatus.Draft),
                StatusDisplayName = AppConstants.Enums.PackageStatus.Draft.GetDisplayName(),
            }, new PackageStatusOption
            {
                Id = (int) AppConstants.Enums.PackageStatus.New,
                StatusName = nameof(AppConstants.Enums.PackageStatus.New),
                StatusDisplayName = AppConstants.Enums.PackageStatus.New.GetDisplayName(),
            }, new PackageStatusOption
            {
                Id = (int) AppConstants.Enums.PackageStatus.SubmittedForApproval,
                StatusName = nameof(AppConstants.Enums.PackageStatus.SubmittedForApproval),
                StatusDisplayName = AppConstants.Enums.PackageStatus.SubmittedForApproval.GetDisplayName(),
            }, new PackageStatusOption
            {
                Id = (int) AppConstants.Enums.PackageStatus.Rejected,
                StatusName = nameof(AppConstants.Enums.PackageStatus.Rejected),
                StatusDisplayName = AppConstants.Enums.PackageStatus.Rejected.GetDisplayName(),
            }, new PackageStatusOption
            {
                Id = (int) AppConstants.Enums.PackageStatus.ClarificationNeeded,
                StatusName = nameof(AppConstants.Enums.PackageStatus.ClarificationNeeded),
                StatusDisplayName = AppConstants.Enums.PackageStatus.ClarificationNeeded.GetDisplayName(),
            }, new PackageStatusOption
            {
                Id = (int) AppConstants.Enums.PackageStatus.Approved,
                StatusName = nameof(AppConstants.Enums.PackageStatus.Approved),
                StatusDisplayName = AppConstants.Enums.PackageStatus.Approved.GetDisplayName(),
            });
        }
    }
}
