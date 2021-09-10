using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class InvoiceNoteChargeTypeSeed : IEntityTypeConfiguration<InvoiceNoteChargeType>
    {
        public void Configure(EntityTypeBuilder<InvoiceNoteChargeType> builder)
        {
            builder.HasData(
                new InvoiceNoteChargeType
                {
                    Id = (int) InvoiceNoteChargeTypeEnum.OverCharge,
                    ChargeTypeName = nameof(InvoiceNoteChargeTypeEnum.OverCharge)
                },
                new InvoiceNoteChargeType
                {
                    Id = (int) InvoiceNoteChargeTypeEnum.UnderCharge,
                    ChargeTypeName = nameof(InvoiceNoteChargeTypeEnum.UnderCharge)
                });
        }
    }
}
