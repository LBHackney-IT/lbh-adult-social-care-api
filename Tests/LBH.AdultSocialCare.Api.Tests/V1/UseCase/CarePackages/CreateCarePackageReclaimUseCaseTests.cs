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
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class CreateCarePackageReclaimUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private CarePackage _defaultPackage;
        private readonly CreateProvisionalCareChargeUseCase _useCase;
        private readonly Mock<ICreatePackageResourceUseCase> _createPackageResourceUseCase;
        private readonly DateTimeOffset _today = DateTimeOffset.UtcNow.Date;

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
                }
            };

            _dbManager = new Mock<IDatabaseManager>();
            _createPackageResourceUseCase = new Mock<ICreatePackageResourceUseCase>();

            _carePackageGateway = new Mock<ICarePackageGateway>();
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_defaultPackage);
            _useCase = new CreateProvisionalCareChargeUseCase(_carePackageGateway.Object, _dbManager.Object);
        }

        [Fact]
        public async Task ShouldCreateNewProvisionalCharge()
        {
            await _useCase.CreateProvisionalCareCharge(new CarePackageReclaimCreationDomain
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
            _defaultPackage.Reclaims.Clear();
            _defaultPackage.Reclaims.Add(
                new CarePackageReclaim
                {
                    Id = Guid.NewGuid(),
                    Cost = 1m,
                    ClaimCollector = ClaimCollector.Hackney,
                    Status = ReclaimStatus.Cancelled,
                    Type = ReclaimType.CareCharge,
                    SubType = ReclaimSubType.CareChargeProvisional,
                    StartDate = _today.AddDays(-30),
                    EndDate = _today.AddDays(200)
                });
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_defaultPackage);

            // _defaultPackage.Reclaims.Single().Status = ReclaimStatus.Cancelled;

            await _useCase.CreateProvisionalCareCharge(new CarePackageReclaimCreationDomain
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
            await _useCase.CreateProvisionalCareCharge(new CarePackageReclaimCreationDomain
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
                        SubType = ReclaimSubType.CareCharge1To12Weeks,
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

    }
}
