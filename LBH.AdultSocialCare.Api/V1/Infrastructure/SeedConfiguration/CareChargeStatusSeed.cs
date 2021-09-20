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
                Id = (int) ReclaimStatus.Active,
                StatusName = nameof(ReclaimStatus.Active)
            }, new CareChargeStatus
            {
                Id = (int) ReclaimStatus.Ended,
                StatusName = nameof(ReclaimStatus.Ended)
            }, new CareChargeStatus
            {
                Id = (int) ReclaimStatus.Cancelled,
                StatusName = nameof(ReclaimStatus.Cancelled)
            }, new CareChargeStatus
            {
                Id = (int) ReclaimStatus.Future,
                StatusName = nameof(ReclaimStatus.Future)
            });
        }
    }
}
