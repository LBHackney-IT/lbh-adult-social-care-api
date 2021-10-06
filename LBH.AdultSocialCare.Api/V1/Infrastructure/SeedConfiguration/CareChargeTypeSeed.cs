using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class CareChargeTypeSeed : IEntityTypeConfiguration<CareChargeType>
    {
        public void Configure(EntityTypeBuilder<CareChargeType> builder)
        {
            var typeOptions = Enum.GetValues(typeof(CareChargeElementTypeEnum))
                .OfType<CareChargeElementTypeEnum>()
                .Select(x =>
                    new CareChargeType()
                    {
                        Id = (int) x,
                        OptionName = x.GetDisplayName()
                    })
                .ToArray();
            builder.HasData(typeOptions);
        }
    }
}
