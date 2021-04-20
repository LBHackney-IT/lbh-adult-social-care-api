using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class UserSeed : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(new Users
            {
                Id = Guid.NewGuid(),
                FirstName = "Furkan",
                LastName = "Kayar",
                HackneyId = 1111,
                AddressLine1 = "Queens Gate",
                Town = "London",
                PostCode = "W11",
                RoleId = 1
            }, new Users
            {
                Id = Guid.NewGuid(),
                FirstName = "Duncan",
                LastName = "Okeno",
                HackneyId = 4444,
                AddressLine1 = "Nairobi",
                Town = "Nairobi",
                PostCode = "W11",
                RoleId = 2
            });
        }
    }
}
