using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class CareChargeTypeSeed : IEntityTypeConfiguration<CareChargeType>
    {
        public void Configure(EntityTypeBuilder<CareChargeType> builder)
        {
            builder.HasData(new CareChargeType
            {
                Id = 1,
                OptionName = "Without Property 1-12 Weeks"
            }, new CareChargeType
            {
                Id = 2,
                OptionName = "Without Property 13+ Weeks"
            });
        }
    }
}
