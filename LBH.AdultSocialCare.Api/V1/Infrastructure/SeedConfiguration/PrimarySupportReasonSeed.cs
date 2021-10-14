using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
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
                PrimarySupportReasonName = "Physical Support",
                CederBudgetCode = "Ceder - Physical Support"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 2,
                PrimarySupportReasonName = "Sensory Support",
                CederBudgetCode = "Ceder Sensory Support"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 3,
                PrimarySupportReasonName = "Support with memory and cognition",
                CederBudgetCode = "Ceder Support with memory and cognition"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 4,
                PrimarySupportReasonName = "Learning Disability Support",
                CederBudgetCode = "Ceder Learning Disability Support"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 5,
                PrimarySupportReasonName = "Mental Health Support (ASC)",
                CederBudgetCode = "Ceder Mental Health Support (ASC)"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 6,
                PrimarySupportReasonName = "Social Support",
                CederBudgetCode = "Ceder Social Support"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 7,
                PrimarySupportReasonName = "Mental Health Support (ELFT)",
                CederBudgetCode = "Ceder Mental Health Support (ELFT)"
            });
        }
    }
}
