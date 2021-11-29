using LBH.AdultSocialCare.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Data.SeedConfiguration
{
    public class PrimarySupportReasonSeed : IEntityTypeConfiguration<PrimarySupportReason>
    {
        public void Configure(EntityTypeBuilder<PrimarySupportReason> builder)
        {
            builder.HasData(new PrimarySupportReason
            {
                PrimarySupportReasonId = 1,
                PrimarySupportReasonName = "Physical Support",
                CederBudgetCode = "D0822"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 2,
                PrimarySupportReasonName = "Sensory Support",
                CederBudgetCode = "D0823"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 3,
                PrimarySupportReasonName = "Support with memory and cognition",
                CederBudgetCode = "D0824"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 4,
                PrimarySupportReasonName = "Learning Disability Support",
                CederBudgetCode = "D0825"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 5,
                PrimarySupportReasonName = "Mental Health Support (ASC)",
                CederBudgetCode = "D0826"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 6,
                PrimarySupportReasonName = "Social Support",
                CederBudgetCode = "D0828"
            }, new PrimarySupportReason
            {
                PrimarySupportReasonId = 7,
                PrimarySupportReasonName = "Mental Health Support (ELFT)",
                CederBudgetCode = "D0829"
            });
        }
    }
}
