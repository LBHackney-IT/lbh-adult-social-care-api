using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CareCharge;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class InvoiceNoteChargeTypeSeed : IEntityTypeConfiguration<InvoiceNoteChargeType>
    {
        public void Configure(EntityTypeBuilder<InvoiceNoteChargeType> builder)
        {
            var typeOptions = Enum.GetValues(typeof(InvoiceNoteChargeTypeEnum))
                .OfType<InvoiceNoteChargeTypeEnum>()
                .Select(x =>
                    new InvoiceNoteChargeType()
                    {
                        Id = (int) x,
                        ChargeTypeName = x.ToString()
                    })
                .ToArray();
            builder.HasData(typeOptions);
        }
    }
}
