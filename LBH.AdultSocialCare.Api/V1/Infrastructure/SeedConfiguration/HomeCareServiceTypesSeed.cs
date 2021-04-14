using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
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
                Id = new Guid("E2326B8C-98FF-411F-83DE-0BC4850FB0EF"),
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Personal Home Care"
            }, new HomeCareServiceType
            {
                Id = new Guid("572D7564-ED86-4FD6-B516-6A2344FB62DB"),
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Domestic Care"
            }, new HomeCareServiceType
            {
                Id = new Guid("542080D8-2E23-46DB-A7D3-B101A5DC244D"),
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Live-in Care"
            }, new HomeCareServiceType
            {
                Id = new Guid("292CE8C1-70E2-4EEE-A479-C09F7988ACD9"),
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow,
                ServiceName = "Escort Care"
            });
        }

    }

}
