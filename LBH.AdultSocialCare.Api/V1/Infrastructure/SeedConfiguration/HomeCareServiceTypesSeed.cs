using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{

    public class HomeCareServiceTypesSeed : IEntityTypeConfiguration<HomeCareServiceType>
    {

        public void Configure(EntityTypeBuilder<HomeCareServiceType> builder)
        {
            builder.HasData(new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.Personal,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Personal Home Care"
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.Domestic,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Domestic Care"
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.LiveIn,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Live-in Care"
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.Escort,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Escort Care"
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.NightOwl,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Night Owl"
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.WakingNights,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Waking Nights"
            }, new HomeCareServiceType
            {
                Id = (int) HomeCareServiceTypeEnum.SleepingNights,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Sleeping Nights"
            });
        }

    }

}
