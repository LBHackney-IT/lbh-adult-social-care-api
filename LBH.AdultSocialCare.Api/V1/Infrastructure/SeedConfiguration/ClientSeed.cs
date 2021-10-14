using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class ClientSeed : IEntityTypeConfiguration<ServiceUser>
    {
        public void Configure(EntityTypeBuilder<ServiceUser> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new ServiceUser
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
            }, new ServiceUser
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
            }, new ServiceUser
            {
                Id = new Guid("91990f8a-b325-43eb-8482-0d1c7dcf8cd5"),
                FirstName = "Allie",
                LastName = "Grater",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Mid-Level",
                PreferredContact = "Phone",
                HackneyId = 65653,
                AddressLine1 = "Z Street",
                Town = "Ealing",
                PostCode = "W4",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("6691fbfc-e398-41e0-8733-9ae98ebe2ba8"),
                FirstName = "Constance",
                LastName = "Noring",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 88888,
                AddressLine1 = "XX Road",
                Town = "Cardiff",
                PostCode = "C2",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("a99f4b55-7c49-4bad-a338-86c6d79dfe36"),
                FirstName = "Isabelle",
                LastName = "Ringing",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 99999,
                AddressLine1 = "YY Street",
                Town = "Norwich",
                PostCode = "N7",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("61e8b256-3bb6-42a2-9d24-38a44a3bd5f2"),
                FirstName = "Harriet",
                LastName = "Upp",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 11111,
                AddressLine1 = "Old Trafford",
                Town = "Manchester",
                PostCode = "M8",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("de846662-e8fe-4c47-bd0a-20113b71e02d"),
                FirstName = "Willie",
                LastName = "Makit",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Mail",
                HackneyId = 22222,
                AddressLine1 = "Anfield",
                Town = "Liverpool",
                PostCode = "L9",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("0c6edb1d-799b-4ce3-98a8-e6fe271c4a8f"),
                FirstName = "Mark",
                LastName = "Ateer",
                DateOfBirth = new DateTime(1980, 1, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 33322,
                AddressLine1 = "New Road",
                Town = "Ipswich",
                PostCode = "I12",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("9a84d6c3-e570-4f30-8bb2-80425d6f8e60"),
                FirstName = "Colin",
                LastName = "Edmunds",
                DateOfBirth = new DateTime(1958, 10, 12),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 10532,
                AddressLine1 = "Y Street",
                Town = "Brighton",
                PostCode = "B4",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("14ffd252-a98b-4489-ab58-6db72ed317c6"),
                FirstName = "Tim",
                LastName = "Gray",
                DateOfBirth = new DateTime(1944, 6, 6),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 57806,
                AddressLine1 = "X Town",
                Town = "Watford",
                PostCode = "W2",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("3c96cc5b-557e-42eb-957b-f9b0b7302ad7"),
                FirstName = "Jake",
                LastName = "Hart",
                DateOfBirth = new DateTime(1950, 6, 17),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 33322,
                AddressLine1 = "X Road",
                Town = "Dorset",
                PostCode = "D1",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new ServiceUser
            {
                Id = new Guid("dde0741c-f9a9-4d42-b889-a1d17864d77e"),
                FirstName = "Emma",
                LastName = "Coleman",
                DateOfBirth = new DateTime(1940, 4, 1),
                CanSpeakEnglish = "Fluent",
                PreferredContact = "Phone",
                HackneyId = 66779,
                AddressLine1 = "New Town",
                Town = "Newcastle",
                PostCode = "E1",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }
    }
}
