using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class InvoiceItemPriceEffectSeed : IEntityTypeConfiguration<InvoiceItemPriceEffect>
    {
        public void Configure(EntityTypeBuilder<InvoiceItemPriceEffect> builder)
        {
            var priceEffectOptions = Enum.GetValues(typeof(InvoiceItemPriceEffectEnum))
                .OfType<InvoiceItemPriceEffectEnum>()
                .Select(x =>
                    new InvoiceItemPriceEffect()
                    {
                        Id = (int) x,
                        EffectName = x.ToString()
                    })
                .ToArray();
            builder.HasData(priceEffectOptions);
        }
    }
}
