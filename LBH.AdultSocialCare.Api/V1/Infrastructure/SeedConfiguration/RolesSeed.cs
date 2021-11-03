using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class RolesSeed : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            var roleOptions = Enum.GetValues(typeof(RolesEnum))
                .OfType<RolesEnum>()
                .Select(x =>
                    new Role()
                    {
                        ConcurrencyStamp = Convert.ToString((int) x),
                        Id = x.GetId(),
                        Name = x.GetDisplayName(),
                        NormalizedName = x.GetNormalizedName()
                    })
                .ToArray();
            builder.HasData(roleOptions);
        }
    }
}
