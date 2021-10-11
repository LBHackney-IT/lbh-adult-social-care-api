using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Common
{
    public class GetSinglePackageCareChargeUseCaseTests : BaseTest
    {
        private Mock<ICarePackageReclaimGateway> _mockGateway;
        private GetSinglePackageCareChargeUseCase _getSinglePackageCareChargeUseCase;
        private Fixture _fixture;

        public GetSinglePackageCareChargeUseCaseTests()
        {
            _mockGateway = new Mock<ICarePackageReclaimGateway>();
            _getSinglePackageCareChargeUseCase = new GetSinglePackageCareChargeUseCase(_mockGateway.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task ShouldReturnSingleCareCharge()
        {
            // Arrange
            var stubbedEntities = _fixture.Create<SinglePackageCareChargeDomain>();
            var packageId = Guid.NewGuid();

            _mockGateway.Setup(x => x.GetSinglePackageCareCharge(packageId))
                .ReturnsAsync(stubbedEntities);

            // Act
            var expectedResponse = stubbedEntities.ToResponse();
            var response = await _getSinglePackageCareChargeUseCase.GetSinglePackageCareCharge(packageId).ConfigureAwait(false);

            // Assert
            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
