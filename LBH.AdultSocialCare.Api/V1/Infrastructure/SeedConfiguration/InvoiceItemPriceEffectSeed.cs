using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class InvoiceItemPriceEffectSeed : IEntityTypeConfiguration<InvoiceItemPriceEffect>
    {
        public void Configure(EntityTypeBuilder<InvoiceItemPriceEffect> builder)
        {
            builder.HasData(
                new InvoiceItemPriceEffect
                {
                    Id = (int) InvoiceItemPriceEffectEnum.None,
                    EffectName = nameof(InvoiceItemPriceEffectEnum.None)
                },
                new InvoiceItemPriceEffect
                {
                    Id = (int) InvoiceItemPriceEffectEnum.Add,
                    EffectName = nameof(InvoiceItemPriceEffectEnum.Add)
                },
                new InvoiceItemPriceEffect
                {
                    Id = (int) InvoiceItemPriceEffectEnum.Subtract,
                    EffectName = nameof(InvoiceItemPriceEffectEnum.Subtract)
                });
        }
    }
}
