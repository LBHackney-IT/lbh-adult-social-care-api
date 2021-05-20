using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.PackageReclaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageReclaimCategorySeed : IEntityTypeConfiguration<ReclaimCategory>
    {
        public void Configure(EntityTypeBuilder<ReclaimCategory> builder)
        {
            builder.HasData(new ReclaimCategory
            {
                ReclaimCategoryId = 1,
                ReclaimCategoryName = "Option 1"
            }, new ReclaimCategory
            {
                ReclaimCategoryId = 2,
                ReclaimCategoryName = "Option 2"
            });
        }
    }
}
