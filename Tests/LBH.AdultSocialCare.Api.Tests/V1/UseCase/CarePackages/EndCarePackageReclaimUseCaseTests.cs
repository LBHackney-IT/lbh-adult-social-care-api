using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Boundary.CarePackages.Request;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class EndCarePackageReclaimUseCaseTests : BaseTest
    {
        private readonly Mock<ICarePackageReclaimGateway> _carePackageReclaimGatewayMock;
        private readonly Mock<IDatabaseManager> _dbManagerMock;
        private readonly Mock<ICarePackageHistoryGateway> _carePackageHistoryGatewayMock;
        private readonly Mock<ICarePackageGateway> _carePackageGatewayMock;
        private readonly EndCareChargeUseCase _useCase;

        public EndCarePackageReclaimUseCaseTests()
        {
            _carePackageReclaimGatewayMock = new Mock<ICarePackageReclaimGateway>();
            _carePackageHistoryGatewayMock = new Mock<ICarePackageHistoryGateway>();
            _carePackageGatewayMock = new Mock<ICarePackageGateway>();
            _dbManagerMock = new Mock<IDatabaseManager>();

            var ensureSingleActivePackageTypePerUserUseCase = new EnsureSingleActivePackageTypePerUserUseCase(_carePackageGatewayMock.Object);

            _useCase = new EndCareChargeUseCase(_carePackageReclaimGatewayMock.Object,
                                                _dbManagerMock.Object,
                                                _carePackageHistoryGatewayMock.Object,
                                                _carePackageGatewayMock.Object);
        }

        [Fact]
        public async void ShouldEndCarePackageReclaim()
        {
            var packageId = Guid.NewGuid();
            var reclaimId = Guid.NewGuid();

            var reclaim = new CarePackageReclaim
            {
                Id = reclaimId,
                Cost = 12.34m,
                CarePackageId = packageId,
                StartDate = DateTimeOffset.Now,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks
            };

            var package = new CarePackage
            {
                Id = packageId,
                Details = new List<CarePackageDetail>
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = DateTimeOffset.Now.AddDays(-10),
                        EndDate = DateTimeOffset.Now.AddDays(10)
                    }
                },
                Reclaims =
                {
                    reclaim
                }
            };

            _carePackageReclaimGatewayMock
                .Setup(g => g.GetAsync(reclaimId, It.IsAny<bool>()))
                .ReturnsAsync(reclaim);

            _carePackageGatewayMock
                .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), true))
                .ReturnsAsync(package);

            package.Reclaims.First().Status = ReclaimStatus.Active;

            var response = await _useCase.ExecuteAsync(reclaimId, new CarePackageReclaimEndRequest()
            {
                EndDate = package.Details.First().EndDate
            });

            _dbManagerMock.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
            response.Status.Should().Be(ReclaimStatus.Ended);
        }

        [Fact]
        public async void ShouldNotAllowEndCarePackageReclaimIfEndDateIsLaterThanCorePackageEndDate()
        {
            var packageId = Guid.NewGuid();
            var reclaimId = Guid.NewGuid();

            var reclaim = new CarePackageReclaim
            {
                Id = reclaimId,
                Cost = 12.34m,
                CarePackageId = packageId,
                StartDate = DateTimeOffset.Now,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks
            };

            var package = new CarePackage
            {
                Id = packageId,
                Details = new List<CarePackageDetail>
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = DateTimeOffset.Now.AddDays(-10),
                        EndDate = DateTimeOffset.Now.AddDays(10)
                    }
                },
                Reclaims =
                {
                    reclaim
                }
            };

            _carePackageReclaimGatewayMock
                .Setup(g => g.GetAsync(reclaimId, It.IsAny<bool>()))
                .ReturnsAsync(reclaim);

            _carePackageGatewayMock
                .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), true))
                .ReturnsAsync(package);

            package.Reclaims.First().Status = ReclaimStatus.Active;

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                var response = await _useCase.ExecuteAsync(reclaimId, new CarePackageReclaimEndRequest()
                {
                    EndDate = DateTimeOffset.Now.AddDays(30)
                });
            });

            //TODO: Fix with correct value
            exception.StatusCode.Should().Be(400);

            _dbManagerMock.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async void ShouldAllowEndCarePackageReclaimForOngoingPackage()
        {
            var packageId = Guid.NewGuid();
            var reclaimId = Guid.NewGuid();

            var reclaim = new CarePackageReclaim
            {
                Id = reclaimId,
                Cost = 12.34m,
                CarePackageId = packageId,
                StartDate = DateTimeOffset.Now,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks
            };

            var package = new CarePackage
            {
                Id = packageId,
                Details = new List<CarePackageDetail>
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = DateTimeOffset.Now.AddDays(-10),
                    }
                },
                Reclaims =
                {
                    reclaim
                }
            };

            _carePackageReclaimGatewayMock
                .Setup(g => g.GetAsync(reclaimId, It.IsAny<bool>()))
                .ReturnsAsync(reclaim);

            _carePackageGatewayMock
                .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), true))
                .ReturnsAsync(package);

            package.Reclaims.First().Status = ReclaimStatus.Active;

            var response = await _useCase.ExecuteAsync(reclaimId, new CarePackageReclaimEndRequest()
            {
                EndDate = DateTimeOffset.Now.AddDays(30)
            });

            //TODO: Fix with correct value
            response.Status.Should().Be(ReclaimStatus.Ended);

            _dbManagerMock.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async void ShouldNotAllowEndCarePackageReclaimIfEndDateIsBeyondThanCorePackageStartDate()
        {
            var packageId = Guid.NewGuid();
            var reclaimId = Guid.NewGuid();

            var reclaim = new CarePackageReclaim
            {
                Id = reclaimId,
                Cost = 12.34m,
                CarePackageId = packageId,
                StartDate = DateTimeOffset.Now,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks
            };

            var package = new CarePackage
            {
                Id = packageId,
                Details = new List<CarePackageDetail>
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = DateTimeOffset.Now.AddDays(-10),
                    }
                },
                Reclaims =
                {
                    reclaim
                }
            };

            _carePackageReclaimGatewayMock
                .Setup(g => g.GetAsync(reclaimId, It.IsAny<bool>()))
                .ReturnsAsync(reclaim);

            _carePackageGatewayMock
                .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), true))
                .ReturnsAsync(package);

            package.Reclaims.First().Status = ReclaimStatus.Active;

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                var response = await _useCase.ExecuteAsync(reclaimId, new CarePackageReclaimEndRequest()
                {
                    EndDate = DateTimeOffset.Now.AddDays(-30)
                });
            });

            //TODO: Fix with correct value
            exception.StatusCode.Should().Be(400);

            _dbManagerMock.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

    }
}
