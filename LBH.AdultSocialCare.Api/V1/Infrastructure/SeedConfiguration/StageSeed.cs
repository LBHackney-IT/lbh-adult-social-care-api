using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class StageSeed : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.HasData(new Stage
            {
                Id = 1,
                StageName = "New",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new Stage
            {
                Id = 2,
                StageName = "Assigned",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new Stage
            {
                Id = 3,
                StageName = "Querying",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new Stage
            {
                Id = 4,
                StageName = "Supplier Sourced",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new Stage
            {
                Id = 5,
                StageName = "Pricing agreed",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            }, new Stage
            {
                Id = 6,
                StageName = "Submitted For Approval",
                CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84")
            });
        }
    }
}
