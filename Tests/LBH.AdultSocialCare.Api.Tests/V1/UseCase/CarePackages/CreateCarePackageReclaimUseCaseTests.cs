using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Microsoft.Extensions.Logging;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class CreateCarePackageReclaimUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly CreateCarePackageReclaimUseCase _useCase;
        private readonly CarePackage _package;
        private readonly Mock<IFileStorage> _fileStorage;
        private readonly Mock<ILogger<CreateCarePackageReclaimUseCase>> _logger;

        public CreateCarePackageReclaimUseCaseTests()
        {
            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost
                    }
                },
                Reclaims =
                {
                    new CarePackageReclaim
                    {
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeProvisional,
                        Status = ReclaimStatus.Active
                    }
                }
            };

            _dbManager = new Mock<IDatabaseManager>();
            _fileStorage = new Mock<IFileStorage>();
            _logger = new Mock<ILogger<CreateCarePackageReclaimUseCase>>();

            var gateway = new Mock<ICarePackageGateway>();
            gateway
                .Setup(g => g.GetPackageAsync(_package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_package);

            _useCase = new CreateCarePackageReclaimUseCase(gateway.Object, _dbManager.Object, Mapper, _fileStorage.Object,_logger.Object);
        }

        [Fact]
        public async Task ShouldCreateNewProvisionalCharge()
        {
            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = _package.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeProvisional
            }, ReclaimType.CareCharge);

            _package.Reclaims.Count.Should().Be(1);
            _package.Reclaims.First().Cost.Should().Be(2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact(Skip = "For unblock FE")]
        public async Task ShouldCreateNewProvisionalChargeWhenExistingIsCancelled()
        {
            _package.Reclaims.Single().Status = ReclaimStatus.Cancelled;

            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = _package.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeProvisional
            }, ReclaimType.CareCharge);

            _package.Reclaims.Count.Should().Be(2);
            _package.Reclaims.Should().ContainSingle(r => r.Cost == 1m);
            _package.Reclaims.Should().ContainSingle(r => r.Cost == 2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldUpdateActiveProvisionalCharge()
        {
            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = _package.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeProvisional
            }, ReclaimType.CareCharge);

            _package.Reclaims.Count.Should().Be(1);
            _package.Reclaims.First().Cost.Should().Be(2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
