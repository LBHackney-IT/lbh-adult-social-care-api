using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class TypeOfResidentialCareHomeSeed : IEntityTypeConfiguration<TypeOfResidentialCareHome>
    {
        public void Configure(EntityTypeBuilder<TypeOfResidentialCareHome> builder)
        {
            builder.HasData(new TypeOfResidentialCareHome
            {
                TypeOfCareHomeId = 1,
                TypeOfCareHomeName = "Residential Care Type One"
            }, new TypeOfResidentialCareHome
            {
                TypeOfCareHomeId = 2,
                TypeOfCareHomeName = "Residential Care Type Two"
            });
        }
    }
}
