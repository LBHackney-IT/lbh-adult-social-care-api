using System;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class ChangeCarePackageReclaimsStatusUseCaseTests : BaseTest
    {
        private readonly CarePackageReclaim _reclaim;
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly ChangeCarePackageReclaimsStatusUseCase _useCase;

        public ChangeCarePackageReclaimsStatusUseCaseTests()
        {
            _reclaim = new CarePackageReclaim
            {
                Id = new Guid(),
                Status = ReclaimStatus.Active
            };

            _dbManager = new Mock<IDatabaseManager>();
            var gateway = new Mock<ICarePackageReclaimGateway>();

            gateway
                .Setup(g => g.GetAsync(_reclaim.Id))
                .ReturnsAsync(_reclaim);

            _useCase = new ChangeCarePackageReclaimsStatusUseCase(gateway.Object, _dbManager.Object);
        }

        [Fact]
        public async Task ShouldUpdateStatus()
        {
            await _useCase.ExecuteAsync(_reclaim.Id, ReclaimStatus.Ended);

            _reclaim.Status.Should().Be(ReclaimStatus.Ended);
            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
