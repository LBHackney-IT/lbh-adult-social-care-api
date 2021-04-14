using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{

    public class HomeCareServiceTypesSeed : IEntityTypeConfiguration<HomeCareServiceType>
    {

        public void Configure(EntityTypeBuilder<HomeCareServiceType> builder)
        {
            builder.HasData(new HomeCareServiceType
            {
                Id = 1,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Personal Home Care"
            }, new HomeCareServiceType
            {
                Id = 2,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Domestic Care"
            }, new HomeCareServiceType
            {
                Id = 3,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Live-in Care"
            }, new HomeCareServiceType
            {
                Id = 4,
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Escort Care"
            });
        }

    }

}
