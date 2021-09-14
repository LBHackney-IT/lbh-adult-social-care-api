using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class CareChargeStatusSeed : IEntityTypeConfiguration<CareChargeElementStatus>
    {
        public void Configure(EntityTypeBuilder<CareChargeElementStatus> builder)
        {
            builder.HasData(new CareChargeElementStatus
            {
                Id = (int) CareChargeElementStatusEnum.Active,
                StatusName = nameof(CareChargeElementStatusEnum.Active)
            }, new CareChargeElementStatus
            {
                Id = (int) CareChargeElementStatusEnum.Ended,
                StatusName = nameof(CareChargeElementStatusEnum.Ended)
            }, new CareChargeElementStatus
            {
                Id = (int) CareChargeElementStatusEnum.Cancelled,
                StatusName = nameof(CareChargeElementStatusEnum.Cancelled)
            }, new CareChargeElementStatus
            {
                Id = (int) CareChargeElementStatusEnum.Future,
                StatusName = nameof(CareChargeElementStatusEnum.Future)
            });
        }
    }
}
