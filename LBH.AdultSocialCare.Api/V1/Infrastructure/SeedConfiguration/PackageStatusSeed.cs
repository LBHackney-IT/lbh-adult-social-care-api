using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class PackageStatusSeed : IEntityTypeConfiguration<PackageStatus>
    {
        public void Configure(EntityTypeBuilder<PackageStatus> builder)
        {
            builder.HasData(new PackageStatus
            {
                Id = 1,
                StatusName = "New",
                CreatorId = 1,
                UpdatorId = 1
            }, new PackageStatus
            {
                Id = 2,
                StatusName = "Package Confirmation",
                CreatorId = 1,
                UpdatorId = 1
            }, new PackageStatus
            {
                Id = 3,
                StatusName = "Approved For Brokerage",
                CreatorId = 1,
                UpdatorId = 1
            }, new PackageStatus
            {
                Id = 4,
                StatusName = "Brokering",
                CreatorId = 1,
                UpdatorId = 1
            }, new PackageStatus
            {
                Id = 5,
                StatusName = "Supplier Sourced",
                CreatorId = 1,
                UpdatorId = 1
            }, new PackageStatus
            {
                Id = 6,
                StatusName = "Commercially Approved",
                CreatorId = 1,
                UpdatorId = 1
            }, new PackageStatus
            {
                Id = 7,
                StatusName = "Contracted",
                CreatorId = 1,
                UpdatorId = 1
            });
        }
    }
}
