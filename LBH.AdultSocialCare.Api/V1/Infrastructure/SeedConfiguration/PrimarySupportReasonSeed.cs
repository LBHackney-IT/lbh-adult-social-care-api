using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PrimarySupportReasonSeed : IEntityTypeConfiguration<PrimarySupportReason>
    {
        public void Configure(EntityTypeBuilder<PrimarySupportReason> builder)
        {
            builder.HasData(new PrimarySupportReason
            {
                PrimarySupportReasonId = 1,
                PrimarySupportReasonName = "Primary Support Reason 1",
                CederBudgetCode = "Ceder Budget Code 1"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 2,
                PrimarySupportReasonName = "Primary Support Reason 2",
                CederBudgetCode = "Ceder Budget Code 2"
            });
        }
    }
}
