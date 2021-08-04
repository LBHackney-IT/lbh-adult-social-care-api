using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using LBH.AdultSocialCare.Api.V1.Extensions;

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
                    Id = RolesEnum.SuperAdministrator.GetId(),
                    Name = RolesEnum.SuperAdministrator.GetDisplayName(),
                    NormalizedName = RolesEnum.SuperAdministrator.GetNormalizedName()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.Administrator),
                    Id = RolesEnum.Administrator.GetId(),
                    Name = RolesEnum.Administrator.GetDisplayName(),
                    NormalizedName = RolesEnum.Administrator.GetNormalizedName()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.SocialWorker),
                    Id = RolesEnum.SocialWorker.GetId(),
                    Name = RolesEnum.SocialWorker.GetDisplayName(),
                    NormalizedName = RolesEnum.SocialWorker.GetNormalizedName()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.Broker),
                    Id = RolesEnum.Broker.GetId(),
                    Name = RolesEnum.Broker.GetDisplayName(),
                    NormalizedName = RolesEnum.Broker.GetNormalizedName()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.Approver),
                    Id = RolesEnum.Approver.GetId(),
                    Name = RolesEnum.Approver.GetDisplayName(),
                    NormalizedName = RolesEnum.Approver.GetNormalizedName()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.Finance),
                    Id = RolesEnum.Finance.GetId(),
                    Name = RolesEnum.Finance.GetDisplayName(),
                    NormalizedName = RolesEnum.Finance.GetNormalizedName()
                },
                new Role
                {
                    ConcurrencyStamp = Convert.ToString((int) RolesEnum.User),
                    Id = RolesEnum.User.GetId(),
                    Name = RolesEnum.User.GetDisplayName(),
                    NormalizedName = RolesEnum.User.GetNormalizedName()
                });
        }
    }
}
