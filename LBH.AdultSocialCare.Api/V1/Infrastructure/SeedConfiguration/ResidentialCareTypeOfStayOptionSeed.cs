using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class ResidentialCareTypeOfStayOptionSeed : IEntityTypeConfiguration<ResidentialCareTypeOfStayOption>
    {
        public void Configure(EntityTypeBuilder<ResidentialCareTypeOfStayOption> builder)
        {
            builder.HasData(new ResidentialCareTypeOfStayOption
            {
                TypeOfStayOptionId = 1,
                OptionName = "Interim",
                OptionPeriod = "Under 6 weeks"
            }, new ResidentialCareTypeOfStayOption
            {
                TypeOfStayOptionId = 2,
                OptionName = "Temporary",
                OptionPeriod = "Expected under 52 weeks"
            }, new ResidentialCareTypeOfStayOption
            {
                TypeOfStayOptionId = 3,
                OptionName = "Long Term",
                OptionPeriod = "52+ weeks"
            });
        }
    }
}
