using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class AdditionalNeedsPaymentTypeSeed : IEntityTypeConfiguration<AdditionalNeedsPaymentType>
    {
        public void Configure(EntityTypeBuilder<AdditionalNeedsPaymentType> builder)
        {
            builder.HasData(new AdditionalNeedsPaymentType
            {
                AdditionalNeedsPaymentTypeId = 1,
                OptionName = "Weekly"
            }, new AdditionalNeedsPaymentType
            {
                AdditionalNeedsPaymentTypeId = 2,
                OptionName = "One Off"
            }, new AdditionalNeedsPaymentType
            {
                AdditionalNeedsPaymentTypeId = 3,
                OptionName = "Fixed Period"
            });
        }
    }
}
