using System;
using System.Linq;
using Common.Extensions;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.Common;
using LBH.AdultSocialCare.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Data.SeedConfiguration
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
