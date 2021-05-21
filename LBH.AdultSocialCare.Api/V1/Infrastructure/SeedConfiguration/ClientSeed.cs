using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using LBH.AdultSocialCare.Api.V1.AppConstants;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class ClientSeed : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new Client
            {
                Id = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb80"),
                FirstName = "Furkan",
                LastName = "Kayar",
                DateOfBirth = new DateTime(1990, 5, 5),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 66666,
                AddressLine1 = "Queens Town Road",
                Town = "London",
                PostCode = "SW11",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
