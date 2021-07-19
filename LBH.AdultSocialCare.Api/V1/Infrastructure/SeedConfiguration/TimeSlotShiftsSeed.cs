using System;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{

    public class TimeSlotShiftsSeed : IEntityTypeConfiguration<TimeSlotShifts>
    {

        public void Configure(EntityTypeBuilder<TimeSlotShifts> builder)
        {
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(new TimeSlotShifts
            {
                Id = 1,
                TimeSlotShiftName = "Morning",
                TimeSlotTimeLabel = "08:00 - 10:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new TimeSlotShifts
            {
                Id = 2,
                TimeSlotShiftName = "Mid Morning",
                TimeSlotTimeLabel = "10:00 - 12:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new TimeSlotShifts
            {
                Id = 3,
                TimeSlotShiftName = "Lunch",
                TimeSlotTimeLabel = "12:00 - 14:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new TimeSlotShifts
            {
                Id = 4,
                TimeSlotShiftName = "Afternoon",
                TimeSlotTimeLabel = "14:00 - 17:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new TimeSlotShifts
            {
                Id = 5,
                TimeSlotShiftName = "Evening",
                TimeSlotTimeLabel = "17:00 - 20:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new TimeSlotShifts
            {
                Id = 6,
                TimeSlotShiftName = "Night",
                TimeSlotTimeLabel = "20:00 - 22:00",
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new TimeSlotShifts
            {
                Id = 7,
                TimeSlotShiftName = "Night Owl",
                LinkedToHomeCareServiceTypeId = (int) HomeCareServiceTypeEnum.NightOwl,
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new TimeSlotShifts
            {
                Id = 8,
                TimeSlotShiftName = "Waking Nights",
                LinkedToHomeCareServiceTypeId = (int) HomeCareServiceTypeEnum.WakingNights,
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            }, new TimeSlotShifts
            {
                Id = 9,
                TimeSlotShiftName = "Sleeping Nights",
                LinkedToHomeCareServiceTypeId = (int) HomeCareServiceTypeEnum.SleepingNights,
                CreatorId = 1,
                UpdatorId = 1,
                DateCreated = dateTimeOffset,
                DateUpdated = dateTimeOffset
            });
        }

    }

}
