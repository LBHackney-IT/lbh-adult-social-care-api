using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Moq;
using System;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.V1.Helper;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class CancelCarePackageReclaimsUseCaseTests : BaseTest
    {
        private readonly CarePackageReclaim _reclaim;
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly CancelCarePackageReclaimsUseCase _useCase;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;

        public CancelCarePackageReclaimsUseCaseTests()
        {
            using var localFixture = new MockWebApplicationFactory();

            var carePackage = localFixture.Generator.CreateCarePackage();

            _reclaim = TestDataHelper.CreateCarePackageReclaim(carePackage.Id, ClaimCollector.Hackney,
                ReclaimType.CareCharge, ReclaimSubType.CareChargeProvisional);
            _reclaim.Status = ReclaimStatus.Active;

            carePackage.Reclaims.Add(_reclaim);

            _dbManager = new Mock<IDatabaseManager>();
            var historyGateway = new Mock<ICarePackageHistoryGateway>();
            var gateway = new Mock<ICarePackageReclaimGateway>();
            _carePackageGateway = new Mock<ICarePackageGateway>();

            gateway
                .Setup(g => g.GetAsync(_reclaim.Id, It.IsAny<bool>()))
                .ReturnsAsync(_reclaim);

            _carePackageGateway
                .Setup(g => g.GetPackageAsync(It.IsAny<Guid>(), It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(carePackage);

            _useCase = new CancelCarePackageReclaimsUseCase(gateway.Object, _dbManager.Object, historyGateway.Object, _carePackageGateway.Object);
        }

        [Fact]
        public async Task ShouldUpdateStatus()
        {
            await _useCase.ExecuteAsync(_reclaim.Id);

            _reclaim.Status.Should().Be(ReclaimStatus.Cancelled);
            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
