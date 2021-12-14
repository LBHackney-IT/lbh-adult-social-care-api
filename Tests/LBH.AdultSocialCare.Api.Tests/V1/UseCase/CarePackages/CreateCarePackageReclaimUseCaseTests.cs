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
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
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
        private readonly Mock<ICreatePackageResourceUseCase> _createPackageResourceUseCase;
        private readonly DateTimeOffset _today = DateTimeOffset.Now.Date;

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

            var gateway = new Mock<ICarePackageGateway>();
            gateway
                .Setup(g => g.GetPackageAsync(_package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_package);

            _useCase = new CreateCarePackageReclaimUseCase(gateway.Object, _dbManager.Object, Mapper, _createPackageResourceUseCase.Object);
        }

        [Fact]
        public async Task ShouldCreateNewProvisionalCharge()
        {
            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = _package.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeProvisional,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30)
            }, ReclaimType.CareCharge);

            _package.Reclaims.Count.Should().Be(1);
            _package.Reclaims.First().Cost.Should().Be(2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldCreateNewProvisionalChargeWhenExistingIsCancelled()
        {
            _package.Reclaims.Single().Status = ReclaimStatus.Cancelled;

            await _useCase.CreateCarePackageReclaim(new CarePackageReclaimCreationDomain
            {
                CarePackageId = _package.Id,
                Cost = 2m,
                SubType = ReclaimSubType.CareChargeProvisional,
                AssessmentFileId = Guid.NewGuid(),
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30)
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
                SubType = ReclaimSubType.CareChargeProvisional,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30)
            }, ReclaimType.CareCharge);

            _package.Reclaims.Count.Should().Be(1);
            _package.Reclaims.First().Cost.Should().Be(2m);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
