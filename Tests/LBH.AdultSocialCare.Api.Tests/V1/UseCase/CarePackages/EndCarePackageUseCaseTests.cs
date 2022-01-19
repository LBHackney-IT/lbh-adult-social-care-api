using System;
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
    public class EndCarePackageUseCaseTests : BaseTest
    {
        private readonly EndCarePackageUseCase _useCase;
        private readonly Mock<IDatabaseManager> _dbManager;

        private readonly CarePackage _package;
        private readonly CarePackageDetail _coreCost;

        private readonly DateTimeOffset _today = DateTimeOffset.UtcNow.Date;
        private readonly DateTimeOffset _endDate = DateTimeOffset.UtcNow.Date.AddDays(-1);

        public EndCarePackageUseCaseTests()
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

            _useCase = new EndCarePackageUseCase(gateway.Object, _dbManager.Object);
        }

        [Fact]
        public void ShouldEndPackage()
        {
            _useCase.ExecuteAsync(_package.Id, _endDate, "");

            _package.Status.Should().Be(PackageStatus.Ended);
            _dbManager.VerifySaved();
        }

        [Fact]
        public void ShouldUpdateReclaimStatus()
        {
            _package
                .AddCareChargeProvisional(75.0m, ClaimCollector.Hackney, _coreCost.StartDate, _coreCost.StartDate.AddDays(10))
                .AddCareChargeFor12Weeks(125.0m, ClaimCollector.Hackney, _coreCost.StartDate.AddDays(11));

            _useCase.ExecuteAsync(_package.Id, _endDate, "test");

            _package.Reclaims.Should().ContainSingle(r => r.Status == ReclaimStatus.Ended && r.EndDate == _today.AddDays(-1));
            _package.Reclaims.Should().ContainSingle(r => r.Status == ReclaimStatus.Cancelled && r.SubType == ReclaimSubType.CareCharge1To12Weeks);
            _dbManager.VerifySaved();
        }

        [Fact]
        public void ShouldUpdateDetailsEndDate()
        {
            _package
                .AddWeeklyNeed(250.0m, _coreCost.StartDate, _coreCost.EndDate.GetValueOrDefault().AddDays(10))
                .AddWeeklyNeed(250.0m, _coreCost.StartDate);

            _useCase.ExecuteAsync(_package.Id, _endDate, "test");

            _package.Details.Should().OnlyContain(d => d.EndDate == _endDate);
            _dbManager.VerifySaved();
        }

        [Fact]
        public void ShouldCreateHistoryRecordsForReclaimsCancellation()
        {
            _package
                .AddCareChargeProvisional(100.0m, ClaimCollector.Hackney, _coreCost.StartDate, _coreCost.StartDate.AddDays(10))
                .AddCareChargeFor12Weeks(75.0m, ClaimCollector.Hackney, _coreCost.StartDate.AddDays(11));

            _useCase.ExecuteAsync(_package.Id, _endDate, "test");

            _package.Histories.Count.Should().Be(3);

            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.BrokeredEnded &&
                h.Description == $"{HistoryStatus.BrokeredEnded.GetDisplayName()}: {_endDate:yyyy-MM-dd}" &&
                h.RequestMoreInformation == "test");
            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.PackageInformation &&
                h.Description == $"{ReclaimSubType.CareChargeProvisional.GetDisplayName()} ended");
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

            _useCase.ExecuteAsync(_package.Id, _endDate, "test");

            _package.Histories.Count.Should().Be(3);

            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.BrokeredEnded &&
                h.Description == $"{HistoryStatus.BrokeredEnded.GetDisplayName()}: {_endDate:yyyy-MM-dd}" &&
                h.RequestMoreInformation == "test");
            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.PackageInformation &&
                h.Description == $"Additional Need {_coreCost.StartDate.AddDays(1):yyyy-MM-dd} - {_endDate:yyyy-MM-dd} ended");
            _package.Histories.Should().ContainSingle(h =>
                h.Status == HistoryStatus.PackageInformation &&
                h.Description == $"Additional Need {_coreCost.StartDate.AddDays(2):yyyy-MM-dd} - {_endDate:yyyy-MM-dd} ended");

            _dbManager.VerifySaved();
        }
    }
}
