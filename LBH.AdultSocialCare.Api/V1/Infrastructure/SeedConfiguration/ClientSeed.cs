using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class ClientSeed : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            builder.HasData(new Clients
            {
                Id = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                FirstName = "Furkan",
                LastName = "Kayar",
                DateOfBirth = new DateTime(1990, 5, 5),
                HackneyId = 66666,
                AddressLine1 = "Queens Town Road",
                Town = "London",
                PostCode = "SW11",
            });
        }
    }
}
