using System;
using System.Linq;
using Common.Extensions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Core;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using LBH.AdultSocialCare.TestFramework.Extensions;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class CancelCarePackageUseCaseTests : BaseTest
    {
        private readonly CancelCarePackageUseCase _useCase;
        private readonly Mock<IDatabaseManager> _dbManager;

        private readonly CarePackage _package;
        private readonly CarePackageDetail _coreCost;
        private readonly DateTimeOffset _today = DateTimeOffset.UtcNow.Date;

        public CancelCarePackageUseCaseTests()
        {
            _package = TestDataHelper
                .CreateCarePackage()
                .AddCoreCost(1000.0m, _today.AddDays(-5), _today.AddDays(30));

            _coreCost = _package.GetCoreCostDetail();

            _dbManager = new Mock<IDatabaseManager>();
            var gateway = new Mock<ICarePackageGateway>();

            gateway
                .Setup(g => g.GetPackageAsync(It.IsAny<Guid>(), It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_package);

            _useCase = new CancelCarePackageUseCase(gateway.Object, _dbManager.Object);
        }

        [Fact]
        public void ShouldCancelPackage()
        {
            _useCase.ExecuteAsync(_package.Id, "");

            _package.Status.Should().Be(PackageStatus.Cancelled);
            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldCancelReclaims()
        {
            _package
                .AddCareChargeProvisional(100.0m, ClaimCollector.Hackney, _coreCost.StartDate, _coreCost.StartDate.AddDays(10))
                .AddCareChargeFor12Weeks(75.0m, ClaimCollector.Hackney, _coreCost.StartDate.AddDays(11));

            _useCase.ExecuteAsync(_package.Id, "test");

            _package.Reclaims.Should().OnlyContain(r => r.Status == ReclaimStatus.Cancelled);
            _dbManager.VerifySaved();
        }

        [Fact]
        public void ShouldUpdateDetailsEndDate()
        {
            _package
                .AddWeeklyNeed(250.0m, _coreCost.StartDate, _coreCost.EndDate.GetValueOrDefault().AddDays(10))
                .AddWeeklyNeed(250.0m, _coreCost.StartDate);

            _useCase.ExecuteAsync(_package.Id, "test");

            _package.Details.Should().OnlyContain(d => d.EndDate == _today);
            _dbManager.VerifySaved();
        }

        [Fact]
        public void ShouldCreateHistoryRecordsForReclaimsCancellation()
        {
            _package
                .AddCareChargeProvisional(100.0m, ClaimCollector.Hackney, _coreCost.StartDate, _coreCost.StartDate.AddDays(10))
                .AddCareChargeFor12Weeks(75.0m, ClaimCollector.Hackney, _coreCost.StartDate.AddDays(11));

            _useCase.ExecuteAsync(_package.Id, "test");

            _package.Histories.Count.Should().Be(3);

            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.Cancelled &&
                h.Description == HistoryStatus.Cancelled.GetDisplayName() &&
                h.RequestMoreInformation == "test");
            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.PackageInformation &&
                h.Description == $"{ReclaimSubType.CareChargeProvisional.GetDisplayName()} cancelled");
            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.PackageInformation &&
                h.Description == $"{ReclaimSubType.CareCharge1To12Weeks.GetDisplayName()} cancelled");

            _dbManager.VerifySaved();
        }

        [Fact]
        public void ShouldCreateHistoryRecordsForUpdatedDetails()
        {
            _package
                .AddWeeklyNeed(250.0m, _coreCost.StartDate, _coreCost.StartDate.AddDays(1))
                .AddWeeklyNeed(250.0m, _coreCost.StartDate.AddDays(1), _coreCost.EndDate.GetValueOrDefault().AddDays(10))
                .AddWeeklyNeed(250.0m, _coreCost.StartDate.AddDays(2));

            _useCase.ExecuteAsync(_package.Id, "test");

            _package.Histories.Count.Should().Be(3);

            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.Cancelled &&
                h.Description == HistoryStatus.Cancelled.GetDisplayName() &&
                h.RequestMoreInformation == "test");
            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.PackageInformation &&
                h.Description == $"Additional Need {_coreCost.StartDate.AddDays(1):yyyy-MM-dd} - {_today:yyyy-MM-dd} cancelled");
            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.PackageInformation &&
                h.Description == $"Additional Need {_coreCost.StartDate.AddDays(2):yyyy-MM-dd} - {_today:yyyy-MM-dd} cancelled");

            _dbManager.VerifySaved();
        }
    }
}
