using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCarePackageReclaims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageReclaimAmountOptionSeed : IEntityTypeConfiguration<HomeCarePackageReclaimAmountOption>
    {
        public void Configure(EntityTypeBuilder<HomeCarePackageReclaimAmountOption> builder)
        {
            builder.HasData(new HomeCarePackageReclaimAmountOption
            {
                AmountOptionId = 1,
                AmountOptionName = "Percentage"
            }, new HomeCarePackageReclaimAmountOption
            {
                AmountOptionId = 2,
                AmountOptionName = "Fixed amount - one off"
            }, new HomeCarePackageReclaimAmountOption
            {
                AmountOptionId = 3,
                AmountOptionName = "Fixed amount - weekly"
            });
        }
    }
}
