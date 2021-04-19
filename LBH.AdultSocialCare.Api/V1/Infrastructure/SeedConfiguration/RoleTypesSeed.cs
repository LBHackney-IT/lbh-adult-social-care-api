using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class RoleTypesSeed : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasData(new Roles
            {
                Id = 1,
                RoleName = "Social Worker",
                IsDefault = true,
                Sequence = 1,
                CreatorId = 1,
                UpdatorId = 1
            }, new Roles
            {
                Id = 2,
                RoleName = "Broker",
                IsDefault = false,
                Sequence = 2,
                CreatorId = 1,
                UpdatorId = 1
            });
        }
    }
}
