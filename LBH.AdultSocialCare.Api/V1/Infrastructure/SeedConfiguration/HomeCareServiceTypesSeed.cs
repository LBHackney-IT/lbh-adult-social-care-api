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
                CreatorId = 1,
                UpdatorId = 1,
                ServiceName = "Personal Home Care",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.Domestic,
                CreatorId = 1,
                UpdatorId = 1,
                ServiceName = "Domestic Care",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.LiveIn,
                CreatorId = 1,
                UpdatorId = 1,
                ServiceName = "Live-in Care",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.Escort,
                CreatorId = 1,
                UpdatorId = 1,
                ServiceName = "Escort Care",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.NightOwl,
                CreatorId = 1,
                UpdatorId = 1,
                ServiceName = "Night Owl",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.WakingNights,
                CreatorId = 1,
                UpdatorId = 1,
                ServiceName = "Waking Nights",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.SleepingNights,
                CreatorId = 1,
                UpdatorId = 1,
                ServiceName = "Sleeping Nights",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }

    }

}
