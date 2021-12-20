using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class CreateCarePackageReclaimUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly CreateCarePackageReclaimUseCase _useCase;
        private readonly CarePackage _defaultPackage;
        private readonly Mock<ICreatePackageResourceUseCase> _createPackageResourceUseCase;
        private readonly DateTimeOffset _today = DateTimeOffset.Now.Date;

        public CreateCarePackageReclaimUseCaseTests()
        {
            _defaultPackage = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    }
                },
                Reclaims =
                {
                    new CarePackageReclaim
                    {
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        Status = ReclaimStatus.Active,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    }
                }
            };

            _dbManager = new Mock<IDatabaseManager>();
            _createPackageResourceUseCase = new Mock<ICreatePackageResourceUseCase>();

            _carePackageGateway = new Mock<ICarePackageGateway>();
            _useCase = new CreateCarePackageReclaimUseCase(_carePackageGateway.Object, _dbManager.Object, Mapper, _createPackageResourceUseCase.Object);
        }

        [Fact]
        public async Task ShouldCreateNewProvisionalCharge()
        {
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_defaultPackage);

            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = _defaultPackage.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeProvisional,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30)
            }, ReclaimType.CareCharge);

            _defaultPackage.Reclaims.Count.Should().Be(1);
            _defaultPackage.Reclaims.First().Cost.Should().Be(2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldCreateNewProvisionalChargeWhenExistingIsCancelled()
        {
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_defaultPackage);

            _defaultPackage.Reclaims.Single().Status = ReclaimStatus.Cancelled;

            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = _defaultPackage.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeProvisional,
                AssessmentFileId = Guid.NewGuid(),
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30)
            }, ReclaimType.CareCharge);

            _defaultPackage.Reclaims.Count.Should().Be(2);
            _defaultPackage.Reclaims.Should().ContainSingle(r => r.Cost == 1m);
            _defaultPackage.Reclaims.Should().ContainSingle(r => r.Cost == 2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldUpdateActiveProvisionalCharge()
        {
            _carePackageGateway
               .Setup(g => g.GetPackageAsync(_defaultPackage.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(_defaultPackage);

            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = _defaultPackage.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeProvisional,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30)
            }, ReclaimType.CareCharge);

            _defaultPackage.Reclaims.Count.Should().Be(1);
            _defaultPackage.Reclaims.First().Cost.Should().Be(2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldSetEndDateOfProvisionalWithStartDateOfCareChargeWithoutPropertyOneToTwelveWeeks()
        {
            var package = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    }
                },
                Reclaims =
                {
                    new CarePackageReclaim
                    {
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        Status = ReclaimStatus.Active,
                        StartDate = _today.AddDays(-20),
                        EndDate = _today.AddDays(30)
                    }
                }
            };
            _carePackageGateway
               .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(package);

            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = package.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                StartDate = _today.AddDays(-20),
                EndDate = _today.AddDays(30)
            }, ReclaimType.CareCharge);

            package.Reclaims.Count.Should().Be(2);
            package.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Should().NotBeNull();
            package.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Status.Should().NotBe(ReclaimStatus.Active);
            package.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).EndDate.Should().Be(_today.AddDays(-21));
            package.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks).Status.Should().Be(ReclaimStatus.Active);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldSetCancelledProvisionalIfCareChargeWithoutPropertyOneToTwelveWeeksOverlap()
        {
            var package = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    }
                },
                Reclaims =
                {
                    new CarePackageReclaim
                    {
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        Status = ReclaimStatus.Active,
                        StartDate = _today.AddDays(-20),
                        EndDate = _today.AddDays(30)
                    }
                }
            };
            _carePackageGateway
               .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(package);

            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = package.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                StartDate = _today.AddDays(-20),
                EndDate = _today.AddDays(30)
            }, ReclaimType.CareCharge);

            package.Reclaims.Count.Should().Be(2);
            package.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Should().NotBeNull();
            package.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).Status.Should().Be(ReclaimStatus.Cancelled);
            package.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeProvisional).EndDate.Should().Be(_today.AddDays(-20));
            package.Reclaims.FirstOrDefault(x => x.SubType == ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks).Status.Should().Be(ReclaimStatus.Active);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldNotAllowAddingProvisionalIfReclaimExist()
        {
            var package = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    }
                },
                Reclaims =
                {
                    new CarePackageReclaim
                    {
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        Status = ReclaimStatus.Cancelled,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(-20)
                    },
                    new CarePackageReclaim
                    {
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                        Status = ReclaimStatus.Active,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    },
                }
            };
            _carePackageGateway
               .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(package);

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _useCase.CreateProvisionalCareCharge(new CarePackageReclaimCreationDomain
                {
                    CarePackageId = package.Id,
                    Cost = 2m,
                    SubType = ReclaimSubType.CareChargeProvisional,
                    StartDate = _today.AddDays(-30),
                    EndDate = _today.AddDays(10)
                }, ReclaimType.CareCharge);
            });

            //TODO: Fix with correct value
            exception.StatusCode.Should().Be(400);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ShouldNotAllowOverlapBetweenCareCharges()
        {
            var package = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    }
                },
                Reclaims =
                {
                    new CarePackageReclaim
                    {
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        Status = ReclaimStatus.Cancelled,
                        StartDate = _today.AddDays(-30),
                        EndDate = _today.AddDays(30)
                    }
                }
            };
            _carePackageGateway
               .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(package);

            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = package.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(-20)
            }, ReclaimType.CareCharge);

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
                {
                    CarePackageId = package.Id,
                    Cost = 2m,
                    SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks,
                    StartDate = _today.AddDays(-25),
                    EndDate = _today.AddDays(-10)
                }, ReclaimType.CareCharge);
            });

            //TODO: Fix with correct value
            exception.StatusCode.Should().Be(500);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
