using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageReclaimCategorySeed : IEntityTypeConfiguration<HomeCarePackageReclaimCategory>
    {
        public void Configure(EntityTypeBuilder<HomeCarePackageReclaimCategory> builder)
        {
            builder.HasData(new HomeCarePackageReclaimCategory
            {
                ReclaimCategoryId = 1,
                ReclaimCategoryName = "Option 1"
            }, new HomeCarePackageReclaimCategory
            {
                ReclaimCategoryId = 2,
                ReclaimCategoryName = "Option 2"
            });
        }
    }
}
