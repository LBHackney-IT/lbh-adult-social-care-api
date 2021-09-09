using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
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
                Id = (int) CareChargeElementStatusEnum.Active,
                StatusName = nameof(CareChargeElementStatusEnum.Active)
            }, new CareChargeStatus
            {
                Id = (int) CareChargeElementStatusEnum.Ended,
                StatusName = nameof(CareChargeElementStatusEnum.Ended)
            }, new CareChargeStatus
            {
                Id = (int) CareChargeElementStatusEnum.Cancelled,
                StatusName = nameof(CareChargeElementStatusEnum.Cancelled)
            }, new CareChargeStatus
            {
                Id = (int) CareChargeElementStatusEnum.Future,
                StatusName = nameof(CareChargeElementStatusEnum.Future)
            });
        }
    }
}
