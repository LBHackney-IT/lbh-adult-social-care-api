using System;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Data.SeedConfiguration
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
                });
        }
    }
}
