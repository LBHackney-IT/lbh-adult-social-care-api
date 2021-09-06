using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class CareChargeStatusSeed : IEntityTypeConfiguration<CareChargeStatus>
    {
        public void Configure(EntityTypeBuilder<CareChargeStatus> builder)
        {
            builder.HasData(new CareChargeStatus
            {
                Id = 1,
                StatusName = "Active"
            }, new CareChargeStatus
            {
                Id = 2,
                StatusName = "End"
            }, new CareChargeStatus
            {
                Id = 3,
                StatusName = "Cancelled"
            }, new CareChargeStatus
            {
                Id = 4,
                StatusName = "Future"
            });
        }
    }
}
