using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class RolesSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.SuperAdministrator),
                    Id = new Guid(RolesEnum.SuperAdministrator.ToDescription()),
                    Name = RolesEnum.SuperAdministrator.GetDisplayName(),
                    NormalizedName = RolesEnum.SuperAdministrator.GetDisplayName().ToUpper()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.Administrator),
                    Id = new Guid(RolesEnum.Administrator.ToDescription()),
                    Name = RolesEnum.Administrator.GetDisplayName(),
                    NormalizedName = RolesEnum.Administrator.GetDisplayName().ToUpper()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.SocialWorker),
                    Id = new Guid(RolesEnum.SocialWorker.ToDescription()),
                    Name = RolesEnum.SocialWorker.GetDisplayName(),
                    NormalizedName = RolesEnum.SocialWorker.GetDisplayName().ToUpper()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.Broker),
                    Id = new Guid(RolesEnum.Broker.ToDescription()),
                    Name = RolesEnum.Broker.GetDisplayName(),
                    NormalizedName = RolesEnum.Broker.GetDisplayName().ToUpper()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.User),
                    Id = new Guid(RolesEnum.User.ToDescription()),
                    Name = RolesEnum.User.GetDisplayName(),
                    NormalizedName = RolesEnum.User.GetDisplayName().ToUpper()
                });
        }
    }
}
