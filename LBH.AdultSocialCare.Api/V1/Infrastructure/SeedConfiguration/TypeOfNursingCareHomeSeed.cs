using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class TypeOfNursingCareHomeSeed : IEntityTypeConfiguration<TypeOfNursingCareHome>
    {
        public void Configure(EntityTypeBuilder<TypeOfNursingCareHome> builder)
        {
            builder.HasData(new TypeOfNursingCareHome
            {
                TypeOfCareHomeId = 1,
                TypeOfCareHomeName = "Nursing Care Type One"
            }, new TypeOfNursingCareHome
            {
                TypeOfCareHomeId = 2,
                TypeOfCareHomeName = "Nursing Care Type Two"
            });
        }
    }
}
