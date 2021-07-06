using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
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
                Name = "Furkan Kuyar",
                Email = "furkan@gmail.com",
                UserName = "furkan@gmail.com",
                PhoneNumber = "1234567890",
                LockoutEnabled = false
            };
            passwordHasher.HashPassword(userOne, "Admin*123");

            var userTwo = new User
            {
                Id = new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                Name = "Duncan Okeno",
                Email = "duncan@gmail.com",
                UserName = "duncan@gmail.com",
                PhoneNumber = "12345678910",
                LockoutEnabled = false
            };
            passwordHasher.HashPassword(userTwo, "Admin*123");

            builder.HasData(userOne, userTwo);
        }
    }
}
