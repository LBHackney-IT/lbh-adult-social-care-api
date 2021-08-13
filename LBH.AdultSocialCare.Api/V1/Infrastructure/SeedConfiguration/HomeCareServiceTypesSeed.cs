using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{

    public class HomeCareServiceTypesSeed : IEntityTypeConfiguration<HomeCareServiceType>
    {

        public void Configure(EntityTypeBuilder<HomeCareServiceType> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.Personal,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                ServiceName = "Personal Home Care",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.Domestic,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                ServiceName = "Domestic Care",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.LiveIn,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                ServiceName = "Live-in Care",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.Escort,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                ServiceName = "Escort Care",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.NightOwl,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                ServiceName = "Night Owl",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.WakingNights,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                ServiceName = "Waking Nights",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.SleepingNights,
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                ServiceName = "Sleeping Nights",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }

    }

}
