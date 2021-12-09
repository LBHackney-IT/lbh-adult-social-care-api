using System;
using LBH.AdultSocialCare.Data.Constants;
using LBH.AdultSocialCare.Data.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Data.SeedConfiguration
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

            var migrationUser = new User
            {
                Id = UserConstants.MigrationUserId,
                Name = "Migration User",
                Email = "migration@gmail.com",
                UserName = "migration@gmail.com",
                PhoneNumber = "1234567890",
                LockoutEnabled = true,
                LockoutEnd = new DateTimeOffset(2521, 12, 9, 0, 0, 0, TimeSpan.Zero),
                ConcurrencyStamp = "6b3d758b-924a-482c-af77-e31711a74a2f"
            };
            migrationUser.PasswordHash = passwordHasher.HashPassword(migrationUser, "W_C4mQ3+%c!9RpAx@tCp!UqfQCf2w*Eqwbu4@vmTfXcqj&Y-khg4UdgJH?65hD9L");

            builder.HasData(userOne);
            builder.HasData(migrationUser);
        }
    }
}
