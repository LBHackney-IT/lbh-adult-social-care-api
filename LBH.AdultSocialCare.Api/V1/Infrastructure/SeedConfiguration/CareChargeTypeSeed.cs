using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
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
                Id = (int) CareChargeElementTypeEnum.Provisional,
                OptionName = CareChargeElementTypeEnum.Provisional.GetDisplayName()
            }, new CareChargeType
            {
                Id = (int) CareChargeElementTypeEnum.WithoutPropertyOneToTwelveWeeks,
                OptionName = "Without Property 1-12 Weeks"
            }, new CareChargeType
            {
                Id = (int) CareChargeElementTypeEnum.WithoutPropertyThirteenPlusWeeks,
                OptionName = "Without Property 13+ Weeks"
            });
        }
    }
}
