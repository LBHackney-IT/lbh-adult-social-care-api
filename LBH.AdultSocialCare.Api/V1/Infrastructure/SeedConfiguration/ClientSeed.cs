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
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Client
            {
                Id = new Guid("2f043f6f-09ed-42f0-ab30-c0409c05cb7e"),
                FirstName = "Henry",
                LastName = "Ford",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 55555,
                AddressLine1 = "Old Town Road",
                Town = "Bristol",
                PostCode = "SW16",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Client
            {
                Id = new Guid("91990f8a-b325-43eb-8482-0d1c7dcf8cd5"),
                FirstName = "Allie",
                LastName = "Grater",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 77777,
                AddressLine1 = "Old Town Road",
                Town = "Bristol",
                PostCode = "SW16",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Client
            {
                Id = new Guid("6691fbfc-e398-41e0-8733-9ae98ebe2ba8"),
                FirstName = "Constance",
                LastName = "Noring",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 88888,
                AddressLine1 = "Old Town Road",
                Town = "Bristol",
                PostCode = "SW16",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Client
            {
                Id = new Guid("a99f4b55-7c49-4bad-a338-86c6d79dfe36"),
                FirstName = "Isabelle",
                LastName = "Ringing",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 99999,
                AddressLine1 = "Old Town Road",
                Town = "Bristol",
                PostCode = "SW16",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Client
            {
                Id = new Guid("61e8b256-3bb6-42a2-9d24-38a44a3bd5f2"),
                FirstName = "Harriet",
                LastName = "Upp",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 11111,
                AddressLine1 = "Old Town Road",
                Town = "Bristol",
                PostCode = "SW16",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Client
            {
                Id = new Guid("de846662-e8fe-4c47-bd0a-20113b71e02d"),
                FirstName = "Willie",
                LastName = "Makit",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 22222,
                AddressLine1 = "Old Town Road",
                Town = "Bristol",
                PostCode = "SW16",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new Client
            {
                Id = new Guid("0c6edb1d-799b-4ce3-98a8-e6fe271c4a8f"),
                FirstName = "Mark",
                LastName = "Ateer",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 33322,
                AddressLine1 = "Old Town Road",
                Town = "Bristol",
                PostCode = "SW16",
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
