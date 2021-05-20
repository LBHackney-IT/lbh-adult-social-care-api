using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageReclaimFromSeed : IEntityTypeConfiguration<HomeCarePackageReclaimFrom>
    {
        public void Configure(EntityTypeBuilder<HomeCarePackageReclaimFrom> builder)
        {
            builder.HasData(new HomeCarePackageReclaimFrom
            {
                ReclaimFromId = 1,
                ReclaimFromName = "NHS"
            }, new HomeCarePackageReclaimFrom
            {
                ReclaimFromId = 2,
                ReclaimFromName = "CCG"
            });
        }
    }
}
