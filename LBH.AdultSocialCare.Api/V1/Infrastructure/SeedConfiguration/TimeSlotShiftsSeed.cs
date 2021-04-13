using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{

    public class TimeSlotShiftsSeed : IEntityTypeConfiguration<TimeSlotShifts>
    {

        public void Configure(EntityTypeBuilder<TimeSlotShifts> builder)
        {
            builder.HasData(new TimeSlotShifts
            {
                Id = Guid.NewGuid(),
                TimeSlotShiftName = "Morning",
                TimeSlotTimeLabel = "08:00 - 10:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow
            }, new TimeSlotShifts
            {
                Id = Guid.NewGuid(),
                TimeSlotShiftName = "Mid Morning",
                TimeSlotTimeLabel = "10:00 - 12:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow
            }, new TimeSlotShifts
            {
                Id = Guid.NewGuid(),
                TimeSlotShiftName = "Lunch",
                TimeSlotTimeLabel = "12:00 - 14:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow
            }, new TimeSlotShifts
            {
                Id = Guid.NewGuid(),
                TimeSlotShiftName = "Afternoon",
                TimeSlotTimeLabel = "14:00 - 17:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow
            }, new TimeSlotShifts
            {
                Id = Guid.NewGuid(),
                TimeSlotShiftName = "Evening",
                TimeSlotTimeLabel = "17:00 - 20:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow
            }, new TimeSlotShifts
            {
                Id = Guid.NewGuid(),
                TimeSlotShiftName = "Night",
                TimeSlotTimeLabel = "20:00 - 22:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateUpdated = DateTimeOffset.UtcNow
            });
        }

    }

}
