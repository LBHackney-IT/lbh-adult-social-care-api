using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class UserRolesSeed : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = RolesEnum.SuperAdministrator.ToDescription(),
                    UserId = "aee45700-af9b-4ab5-bb43-535adbdcfb84"
                },
                new IdentityUserRole<string>
                {
                    RoleId = RolesEnum.SocialWorker.ToDescription(),
                    UserId = "aee45700-af9b-4ab5-bb43-535adbdcfb84"
                },
                new IdentityUserRole<string>
                {
                    RoleId = RolesEnum.Broker.ToDescription(),
                    UserId = "aee45700-af9b-4ab5-bb43-535adbdcfb84"
                });
        }
    }
}
