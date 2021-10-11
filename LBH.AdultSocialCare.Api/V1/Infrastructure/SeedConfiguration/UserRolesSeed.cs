using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class UserRolesSeed : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasData(
                new AppUserRole()
                {
                    RoleId = new Guid(RolesEnum.SuperAdministrator.ToDescription()),
                    UserId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
                },
                new AppUserRole
                {
                    RoleId = new Guid(RolesEnum.SocialWorker.ToDescription()),
                    UserId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
                },
                new AppUserRole
                {
                    RoleId = new Guid(RolesEnum.Broker.ToDescription()),
                    UserId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
                });
        }
    }
}
