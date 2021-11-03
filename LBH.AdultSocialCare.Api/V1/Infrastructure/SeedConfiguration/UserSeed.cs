using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var passwordHasher = new PasswordHasher<User>();

            var userOne = new User
            {
                Id = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                Name = "Test User",
                Email = "test@gmail.com",
                UserName = "test@gmail.com",
                PhoneNumber = "1234567890",
                LockoutEnabled = false,
                ConcurrencyStamp = "6b3d758b-924a-482c-af77-e31711a74a2f"
            };
            passwordHasher.HashPassword(userOne, "Admin*123");

            builder.HasData(userOne);
        }
    }
}
