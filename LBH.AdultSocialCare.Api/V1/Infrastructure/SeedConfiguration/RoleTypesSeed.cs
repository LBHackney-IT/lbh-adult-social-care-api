using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class RoleTypesSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new Role
            {
                Id = 1,
                RoleName = "Social Worker",
                IsDefault = true,
                Sequence = 1,
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Role
            {
                Id = 2,
                RoleName = "Broker",
                IsDefault = false,
                Sequence = 2,
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
