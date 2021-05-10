using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LBH.AdultSocialCare.Api.V1.Infrastructure.SeedConfiguration
{
    public class DayCarePackageStatusSeed : IEntityTypeConfiguration<DayCarePackageStatus>
    {
        public void Configure(EntityTypeBuilder<DayCarePackageStatus> builder)
        {
            builder.HasData(
                new DayCarePackageStatus
                {
                    PackageStatusId = 1,
                    StatusName = "New Package",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 1,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageBuilder,
                    PackageAction = PackageActionNameConstants.Created
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 2,
                    StatusName = "Submitted for Approval",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 2,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.NewPackageDetailApproval,
                    PackageAction = PackageActionNameConstants.NewPackage
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 3,
                    StatusName = "Approve Package",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 3,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageDetailApproval,
                    PackageAction = PackageActionNameConstants.Approve
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 4,
                    StatusName = "Reject Package",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 3,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageDetailApproval,
                    PackageAction = PackageActionNameConstants.Reject
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 5,
                    StatusName = "Request More Information",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 3,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageDetailApproval,
                    PackageAction = PackageActionNameConstants.RequestMoreInformation
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 6,
                    StatusName = "Brokerage - New",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 4,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.NewBrokerage,
                    PackageAction = PackageActionNameConstants.NewPackage
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 7,
                    StatusName = "Brokerage - Assigned",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 5,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.NewBrokerage,
                    PackageAction = PackageActionNameConstants.Assigned
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 8,
                    StatusName = "Brokerage - Querying",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 6,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageBrokering,
                    PackageAction = PackageActionNameConstants.Querying
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 9,
                    StatusName = "Brokerage - Supplier Sourced",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 6,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageBrokering,
                    PackageAction = PackageActionNameConstants.SupplierSourced
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 10,
                    StatusName = "Brokerage - Pricing Agreed",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 6,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageBrokering,
                    PackageAction = PackageActionNameConstants.PricingAgreed
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 11,
                    StatusName = "Brokerage - Submitted for Approval",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 7,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.NewBrokerageApproval,
                    PackageAction = PackageActionNameConstants.NewPackage
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 12,
                    StatusName = "Brokerage Approval - Approved",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 8,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.BrokerageApproval,
                    PackageAction = PackageActionNameConstants.Approved
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 13,
                    StatusName = "Brokerage Approval - Rejected",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 8,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.BrokerageApproval,
                    PackageAction = PackageActionNameConstants.Rejected
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 14,
                    StatusName = "Brokerage Approval - Request more information",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 8,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.BrokerageApproval,
                    PackageAction = PackageActionNameConstants.RequestMoreInformation
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = 15,
                    StatusName = "Package Contracted",
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 9,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.Contracting,
                    PackageAction = PackageActionNameConstants.Contracted
                }
            );
        }
    }
}
