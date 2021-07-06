using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class RolesSeed : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    ConcurrencyStamp = Convert.ToString(RolesEnum.SuperAdministrator),
                    Id = RolesEnum.SuperAdministrator.ToDescription(),
                    Name = RolesEnum.SuperAdministrator.GetDisplayName(),
                    NormalizedName = RolesEnum.SuperAdministrator.GetDisplayName().ToUpper()
                },
                new IdentityRole
                {
                    ConcurrencyStamp = Convert.ToString(RolesEnum.Administrator),
                    Id = RolesEnum.Administrator.ToDescription(),
                    Name = RolesEnum.Administrator.GetDisplayName(),
                    NormalizedName = RolesEnum.Administrator.GetDisplayName().ToUpper()
                },
                new IdentityRole
                {
                    ConcurrencyStamp = Convert.ToString(RolesEnum.SocialWorker),
                    Id = RolesEnum.SocialWorker.ToDescription(),
                    Name = RolesEnum.SocialWorker.GetDisplayName(),
                    NormalizedName = RolesEnum.SocialWorker.GetDisplayName().ToUpper()
                },
                new IdentityRole
                {
                    ConcurrencyStamp = Convert.ToString(RolesEnum.Broker),
                    Id = RolesEnum.Broker.ToDescription(),
                    Name = RolesEnum.Broker.GetDisplayName(),
                    NormalizedName = RolesEnum.Broker.GetDisplayName().ToUpper()
                });
        }
    }
}
