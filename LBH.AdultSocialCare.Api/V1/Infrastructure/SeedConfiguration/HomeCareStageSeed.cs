using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class HomeCareStageSeed : IEntityTypeConfiguration<HomeCareStage>
    {
        public void Configure(EntityTypeBuilder<HomeCareStage> builder)
        {
            builder.HasData(new HomeCareStage
            {
                Id = 1,
                StageName = "New",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new HomeCareStage
            {
                Id = 2,
                StageName = "Assigned",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new HomeCareStage
            {
                Id = 3,
                StageName = "Querying",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new HomeCareStage
            {
                Id = 4,
                StageName = "Supplier Sourced",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new HomeCareStage
            {
                Id = 5,
                StageName = "Pricing agreed",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new HomeCareStage
            {
                Id = 6,
                StageName = "Submitted For Approval",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            });
        }
    }
}
