using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageReclaimFromSeed : IEntityTypeConfiguration<ReclaimFrom>
    {
        public void Configure(EntityTypeBuilder<ReclaimFrom> builder)
        {
            builder.HasData(new ReclaimFrom
            {
                ReclaimFromId = 1,
                ReclaimFromName = "NHS"
            }, new ReclaimFrom
            {
                ReclaimFromId = 2,
                ReclaimFromName = "CCG"
            });
        }
    }
}
