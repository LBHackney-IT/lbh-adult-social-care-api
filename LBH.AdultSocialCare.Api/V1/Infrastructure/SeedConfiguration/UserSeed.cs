using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

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
                LockoutEnabled = false,
                ConcurrencyStamp = "6b3d758b-924a-482c-af77-e31711a74a2f"
            };
            passwordHasher.HashPassword(userOne, "Admin*123");

            var userTwo = new User
            {
                Id = new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                Name = "Duncan Okeno",
                Email = "duncan@gmail.com",
                UserName = "duncan@gmail.com",
                PhoneNumber = "12345678910",
                LockoutEnabled = false,
                ConcurrencyStamp = "df0c47dc-a59f-4a66-a2c0-1e844b073466"
            };
            passwordHasher.HashPassword(userTwo, "Admin*123");

            var userThree = new User
            {
                Id = new Guid("3c44e4e1-78b8-471f-9f08-5081a0a534e9"),
                Name = "Burak Ozkan",
                Email = "burak@gmail.com",
                UserName = "burak@gmail.com",
                PhoneNumber = "9046464646",
                LockoutEnabled = false,
                ConcurrencyStamp = "4d24dcde-08b2-4e04-b4f5-c475fab1a22d"
            };
            passwordHasher.HashPassword(userTwo, "Admin*123");

            builder.HasData(userOne, userTwo, userThree);
        }
    }
}
