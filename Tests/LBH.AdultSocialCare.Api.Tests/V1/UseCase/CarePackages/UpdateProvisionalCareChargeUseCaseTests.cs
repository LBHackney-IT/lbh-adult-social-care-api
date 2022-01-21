using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class UpdateProvisionalCareChargeUseCaseTests : BaseTest
    {
        private readonly UpdateProvisionalCareChargeUseCase _useCase;

        private readonly DateTimeOffset _today = DateTimeOffset.UtcNow.Date;

        private readonly CarePackage _package;
        private readonly CarePackageDetail _coreCost;
        private readonly CarePackageReclaim _provisionalCharge;

        public UpdateProvisionalCareChargeUseCaseTests()
        {
            _coreCost = new CarePackageDetail
            {
                Cost = 34.12m,
                Type = PackageDetailType.CoreCost,
                StartDate = _today.AddDays(-10),
                EndDate = _today.AddDays(300)
            };

            _provisionalCharge = new CarePackageReclaim
            {
                Id = Guid.NewGuid(),
                Cost = 12.34m,
                StartDate = _coreCost.StartDate,
                EndDate = _coreCost.EndDate,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeProvisional
            };

            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Details = new List<CarePackageDetail> { _coreCost },
                Reclaims = new List<CarePackageReclaim> { _provisionalCharge }
            };

            var dbManager = new Mock<IDatabaseManager>();
            var carePackageGateway = new Mock<ICarePackageGateway>();

            carePackageGateway
                .Setup(g => g.GetPackageAsync(_package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_package);

            _useCase = new UpdateProvisionalCareChargeUseCase(carePackageGateway.Object, dbManager.Object, Mapper);
        }

        [Fact]
        public async Task ShouldUpdateProvisionalChargeDescription()
        {
            var request = _provisionalCharge.ToUpdateDomain();
            request.ClaimReason = "Updated reason";
            request.Description = "Updated description";

            await _useCase.UpdateAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(1);
            _provisionalCharge.ClaimReason.Should().Be("Updated reason");
            _provisionalCharge.Description.Should().Be("Updated description");
        }

        [Fact]
        public async Task ShouldReplaceProvisionalChargeWhenDatesChanged()
        {
            var request = _provisionalCharge.ToUpdateDomain();
            request.StartDate = _coreCost.StartDate.AddDays(2);
            request.EndDate = _today.AddDays(10);

            await _useCase.UpdateAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(2);

            _package.Reclaims.Should().ContainSingle(
                r => r.Status == ReclaimStatus.Cancelled &&
                     r.StartDate == _coreCost.StartDate &&
                     r.EndDate == _coreCost.EndDate);

            _package.Reclaims.Should().ContainSingle(
                r => r.Status == ReclaimStatus.Active &&
                     r.StartDate == _coreCost.StartDate.AddDays(2) &&
                     r.EndDate == _today.AddDays(10));
        }

        [Fact]
        public void ShouldFailWhenNonProvisionalChargeUpdated()
        {
            _provisionalCharge.SubType = ReclaimSubType.CareCharge1To12Weeks;

            var request = _provisionalCharge.ToUpdateDomain();

            _useCase
                .Invoking(async u => await u.UpdateAsync(_package.Id, request))
                .Should().Throw<ApiException>()
                .Where(ex => ex.Message.Contains("Only provisional care charges supported"));
        }

        [Fact]
        public void ShouldFailWhenPackageHasAnotherOperationalCharges()
        {
            _provisionalCharge.EndDate = _today.AddDays(10);

            _package.Reclaims.Add(new CarePackageReclaim
            {
                Id = Guid.NewGuid(),
                Cost = 34.56m,
                StartDate = _provisionalCharge.EndDate.GetValueOrDefault().AddDays(1),
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareCharge1To12Weeks
            });

            var request = _provisionalCharge.ToUpdateDomain();

            _useCase
                .Invoking(async u => await u.UpdateAsync(_package.Id, request))
                .Should().Throw<ApiException>()
                .Where(ex => ex.Message.Contains("Package has been assessed"));
        }
    }
}
