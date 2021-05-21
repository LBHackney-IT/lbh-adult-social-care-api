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
            var dateTimeOffset = new DateTimeOffset(AppTimeConstants.CreateUpdateDefaultDateTime).ToOffset(TimeSpan.Zero);
            builder.HasData(
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.NewPackageId,
                    StatusName = PackageStatusConstants.NewPackage,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 1,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageBuilder,
                    PackageAction = PackageActionNameConstants.Created,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.SubmittedForApprovalId,
                    StatusName = PackageStatusConstants.SubmittedForApproval,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 2,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.NewPackageDetailApproval,
                    PackageAction = PackageActionNameConstants.NewPackage,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.ApprovePackageId,
                    StatusName = PackageStatusConstants.ApprovePackage,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 3,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageDetailApproval,
                    PackageAction = PackageActionNameConstants.Approve,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.RejectPackageId,
                    StatusName = PackageStatusConstants.RejectPackage,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 3,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageDetailApproval,
                    PackageAction = PackageActionNameConstants.Reject,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.RequestMoreInformationId,
                    StatusName = PackageStatusConstants.RequestMoreInformation,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 3,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageDetailApproval,
                    PackageAction = PackageActionNameConstants.RequestMoreInformation,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokerageNewId,
                    StatusName = PackageStatusConstants.BrokerageNew,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 4,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.NewBrokerage,
                    PackageAction = PackageActionNameConstants.NewPackage,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokerageAssignedId,
                    StatusName = PackageStatusConstants.BrokerageAssigned,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 5,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.NewBrokerage,
                    PackageAction = PackageActionNameConstants.Assigned,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokerageQueryingId,
                    StatusName = PackageStatusConstants.BrokerageQuerying,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 6,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageBrokering,
                    PackageAction = PackageActionNameConstants.Querying,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokerageSupplierSourcedId,
                    StatusName = PackageStatusConstants.BrokerageSupplierSourced,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 6,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageBrokering,
                    PackageAction = PackageActionNameConstants.SupplierSourced,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokeragePricingAgreedId,
                    StatusName = PackageStatusConstants.BrokeragePricingAgreed,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 6,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.PackageBrokering,
                    PackageAction = PackageActionNameConstants.PricingAgreed,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokerageSubmittedForApprovalId,
                    StatusName = PackageStatusConstants.BrokerageSubmittedForApproval,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 7,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.NewBrokerageApproval,
                    PackageAction = PackageActionNameConstants.NewPackage,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokeredDealApprovedId,
                    StatusName = PackageStatusConstants.BrokeredDealApproved,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 8,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.BrokerageApproval,
                    PackageAction = PackageActionNameConstants.Approved,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokeredDealRejectedId,
                    StatusName = PackageStatusConstants.BrokeredDealRejected,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 8,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.BrokerageApproval,
                    PackageAction = PackageActionNameConstants.Rejected,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.BrokeredDealRequestMoreInformationId,
                    StatusName = PackageStatusConstants.BrokeredDealRequestMoreInformation,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 8,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.BrokerageApproval,
                    PackageAction = PackageActionNameConstants.RequestMoreInformation,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                },
                new DayCarePackageStatus
                {
                    PackageStatusId = PackageStatusConstants.PackageContractedId,
                    StatusName = PackageStatusConstants.PackageContracted,
                    CreatorId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    UpdaterId = new Guid("aee45700-af9b-4ab5-bb43-535adbdcfb84"),
                    SequenceNumber = 9,
                    IsDayCareStatus = true,
                    IsStatusActive = true,
                    Stage = PackageStageNameConstants.Contracting,
                    PackageAction = PackageActionNameConstants.Contracted,
                    DateCreated = dateTimeOffset,
                    DateUpdated = dateTimeOffset
                }
            );
        }
    }
}
