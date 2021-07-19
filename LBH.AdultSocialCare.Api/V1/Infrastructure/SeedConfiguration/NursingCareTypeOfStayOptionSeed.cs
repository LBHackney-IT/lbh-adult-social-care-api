using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class NursingCareTypeOfStayOptionSeed : IEntityTypeConfiguration<NursingCareTypeOfStayOption>
    {
        public void Configure(EntityTypeBuilder<NursingCareTypeOfStayOption> builder)
        {
            builder.HasData(new NursingCareTypeOfStayOption
            {
                TypeOfStayOptionId = 1,
                OptionName = "Interim",
                OptionPeriod = "Under 6 weeks"
            }, new NursingCareTypeOfStayOption
            {
                TypeOfStayOptionId = 2,
                OptionName = "Temporary",
                OptionPeriod = "Expected under 52 weeks"
            }, new NursingCareTypeOfStayOption
            {
                TypeOfStayOptionId = 3,
                OptionName = "Long Term",
                OptionPeriod = "52+ weeks"
            });
        }
    }
}
