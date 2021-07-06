using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using LBH.AdultSocialCare.Api.V1.AppConstants;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class UserSeed : IEntityTypeConfiguration<ServiceUser>
    {
        public void Configure(EntityTypeBuilder<ServiceUser> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new ServiceUser
            {
                Id = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                FirstName = "Furkan",
                LastName = "Kayar",
                HackneyId = 1111,
                AddressLine1 = "Queens Gate",
                Town = "London",
                PostCode = "W11",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("1f825b5f-5c65-41fb-8d9e-9d36d78fd6d8"),
                FirstName = "Duncan",
                LastName = "Okeno",
                HackneyId = 4444,
                AddressLine1 = "Nairobi",
                Town = "Nairobi",
                PostCode = "W11",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
