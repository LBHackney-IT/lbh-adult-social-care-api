using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class UserRolesSeed : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid(RolesEnum.SuperAdministrator.ToDescription()),
                    UserId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid(RolesEnum.SocialWorker.ToDescription()),
                    UserId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = new Guid(RolesEnum.Broker.ToDescription()),
                    UserId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
                });
        }
    }
}
