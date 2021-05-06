using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class CarerTypeSeed : IEntityTypeConfiguration<CarerType>
    {
        public void Configure(EntityTypeBuilder<CarerType> builder)
        {
            builder.HasData(new CarerType
            {
                CarerTypeId = 1,
                CarerTypeName = "30m Call",
                CarerTypeMinutes = 30
            }, new CarerType
            {
                CarerTypeId = 2,
                CarerTypeName = "45m Call",
                CarerTypeMinutes = 45
            }, new CarerType
            {
                CarerTypeId = 3,
                CarerTypeName = "60m+ Call",
                CarerTypeMinutes = 60
            });
        }
    }
}
