using System;
using System.Collections.Generic;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.Common
{
    public class CarePackageBrokerageUseCaseTest : BaseTest
    {
        private readonly Mock<ICarePackageGateway> _gatewayMock;
        private readonly Mock<IDatabaseManager> _dbManagerMock;
        private readonly CarePackageBrokerageUseCase _useCase;

        public CarePackageBrokerageUseCaseTest()
        {
            _gatewayMock = new Mock<ICarePackageGateway>();
            _dbManagerMock = new Mock<IDatabaseManager>();

            _useCase = new CarePackageBrokerageUseCase(_gatewayMock.Object, _dbManagerMock.Object);
        }

        [Fact]
        public void ShouldCreateCarePackageDetails()
        {
            var package = new CarePackage
            {
                Id = Guid.NewGuid(),
                Details = new List<CarePackageDetail>()
            };

            _gatewayMock
                .Setup(gateway => gateway.GetPackageAsync(package.Id))
                .ReturnsAsync(package);

            var request = new CarePackageBrokerageDomain
            {
                Details = new List<CarePackageDetailDomain>
                {
                    new CarePackageDetailDomain
                    {
                        Type = PackageDetailType.CoreCost,
                        Cost = 12.34m,
                        StartDate = DateTimeOffset.Now.AddDays(-100)
                    },
                    new CarePackageDetailDomain
                    {
                        Type = PackageDetailType.AdditionalNeedOneOff,
                        Cost = 34.56m,
                        StartDate = DateTimeOffset.Now.AddDays(-100)
                    }
                }
            };

            _useCase.CreateCarePackageBrokerageAsync(package.Id, request);

            package.Details.Count.Should().Be(request.Details.Count);

            _gatewayMock.Verify(mock => mock.GetPackageAsync(package.Id));
            _dbManagerMock.Verify(mock => mock.SaveAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
