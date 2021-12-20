using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class UpdateCarePackageReclaimUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly Mock<ICarePackageReclaimGateway> _carePackageReclaimGateway;
        private readonly Mock<ICarePackageGateway> _carePackageGateway;
        private readonly List<Guid> _requestedIds;
        private readonly CarePackage _defaultPackage;
        private readonly UpdateCarePackageReclaimUseCase _useCase;
        private readonly Mock<ICreatePackageResourceUseCase> _createPackageResourceUseCase;
        private readonly DateTimeOffset _today = DateTimeOffset.Now.Date;

        public UpdateCarePackageReclaimUseCaseTests()
        {
            _dbManager = new Mock<IDatabaseManager>();
            _createPackageResourceUseCase = new Mock<ICreatePackageResourceUseCase>();

            _requestedIds = 3.ItemsOf(Guid.NewGuid);

            var packageId = Guid.NewGuid();
            _defaultPackage = new CarePackage
            {
                Id = packageId,
                Details = new List<CarePackageDetail>
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = DateTimeOffset.Now.AddDays(-10)
                    }
                },
                Reclaims = _requestedIds.Select(id => new CarePackageReclaim
                {
                    Id = id,
                    Cost = 12.34m,
                    CarePackageId = packageId,
                    StartDate = DateTimeOffset.Now,
                    Type = ReclaimType.CareCharge,
                    SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks
                }).ToList()
            };
            _carePackageGateway = new Mock<ICarePackageGateway>();
            _carePackageReclaimGateway = new Mock<ICarePackageReclaimGateway>();

            _useCase = new UpdateCarePackageReclaimUseCase(_carePackageReclaimGateway.Object, _carePackageGateway.Object, _dbManager.Object, Mapper, _createPackageResourceUseCase.Object);
        }

        [Fact]
        public async Task ShouldUpdateProvisionalReclaims()
        {
            _carePackageReclaimGateway
                .Setup(g => g.GetListAsync(It.IsAny<IEnumerable<Guid>>()))
                .ReturnsAsync(((IEnumerable<Guid> ids) => _defaultPackage.Reclaims.Where(r => ids.Contains(r.Id)).ToList()));
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, PackageFields.Details, true))
                .ReturnsAsync(_defaultPackage);

            const decimal newCost = 34.56m;

            var provisionalReclaim = _defaultPackage.Reclaims.First();
            provisionalReclaim.SubType = ReclaimSubType.CareChargeProvisional;

            await _useCase.UpdateListAsync(new CareChargeReclaimBulkUpdateDomain()
            {
                AssessmentFileId = Guid.NewGuid(),
                Reclaims = new List<CarePackageReclaimUpdateDomain>()
                {
                    new CarePackageReclaimUpdateDomain()
                    {
                        Id = provisionalReclaim.Id,
                        Cost = newCost
                    }
                }
            });

            _defaultPackage.Reclaims.Count.Should().Be(_defaultPackage.Reclaims.Count, "No new reclaims should be created when updating provisional one");

            _defaultPackage.Reclaims.Should().ContainSingle(reclaim =>
                reclaim.Cost == newCost &&
                reclaim.SubType == ReclaimSubType.CareChargeProvisional &&
                reclaim.StartDate == _defaultPackage.Details.First().StartDate, "Provisional reclaim start date should be equal to package start date");

            _defaultPackage.Reclaims
                .Where(reclaim => reclaim.SubType != ReclaimSubType.CareChargeProvisional)
                .Should().OnlyContain(reclaim =>
                    reclaim.Cost != newCost &&
                    reclaim.StartDate != _defaultPackage.Details.First().StartDate, "Non-provisional reclaims shouldn't be updated");
        }

        [Fact]
        public async Task ShouldEndExistingReclaimsAndCreateNewOnes()
        {
            _carePackageReclaimGateway
                .Setup(g => g.GetListAsync(It.IsAny<IEnumerable<Guid>>()))
                .ReturnsAsync(((IEnumerable<Guid> ids) => _defaultPackage.Reclaims.Where(r => ids.Contains(r.Id)).ToList()));
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, PackageFields.Details, true))
                .ReturnsAsync(_defaultPackage);

            const decimal newCost = 34.56m;

            var reclaims = _requestedIds.Select(id => new CarePackageReclaimUpdateDomain
            {
                AssessmentFileId = Guid.NewGuid(),
                Id = id,
                Cost = newCost
            }).ToList();

            await _useCase.UpdateListAsync(new CareChargeReclaimBulkUpdateDomain()
            {
                AssessmentFileId = Guid.NewGuid(),
                Reclaims = reclaims
            });

            _defaultPackage.Reclaims
                .Where(reclaim => _requestedIds.Contains(reclaim.Id))
                .Should().OnlyContain(reclaim => reclaim.Status == ReclaimStatus.Ended);
            _defaultPackage.Reclaims
                .Where(reclaim => reclaim.Status != ReclaimStatus.Ended)
                .Should().OnlyContain(reclaim => reclaim.Cost == newCost && !_requestedIds.Contains(reclaim.Id));

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldFailOnMissingReclaim()
        {
            _carePackageReclaimGateway
               .Setup(g => g.GetListAsync(It.IsAny<IEnumerable<Guid>>()))
               .ReturnsAsync(((IEnumerable<Guid> ids) => _defaultPackage.Reclaims.Where(r => ids.Contains(r.Id)).ToList()));
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, PackageFields.Details, true))
                .ReturnsAsync(_defaultPackage);

            var reclaims = 2.ItemsOf(() => new CarePackageReclaimUpdateDomain
            {
                Id = Guid.NewGuid()
            }).ToList();

            _useCase
                .Invoking(useCase => useCase.UpdateListAsync(new CareChargeReclaimBulkUpdateDomain()
                {
                    Reclaims = reclaims
                }))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void ShouldFailOnCancelledReclaim()
        {
            _carePackageReclaimGateway
               .Setup(g => g.GetListAsync(It.IsAny<IEnumerable<Guid>>()))
               .ReturnsAsync(((IEnumerable<Guid> ids) => _defaultPackage.Reclaims.Where(r => ids.Contains(r.Id)).ToList()));
            _carePackageGateway
                .Setup(g => g.GetPackageAsync(_defaultPackage.Id, PackageFields.Details, true))
                .ReturnsAsync(_defaultPackage);

            _defaultPackage.Reclaims.First().Status = ReclaimStatus.Cancelled;

            var request = _requestedIds.Select(id => new CarePackageReclaimUpdateDomain { Id = id }).ToList();

            _useCase
                .Invoking(useCase => useCase.UpdateListAsync(new CareChargeReclaimBulkUpdateDomain()
                {
                    Reclaims = request
                }))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status500InternalServerError);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ShouldAllowUpdateCareChargeWithoutPropertyOneToTwelveWeeksItemIfNoOverlap()
        {
            var packageId = Guid.NewGuid();
            var reclaimId = Guid.NewGuid();
            var thirteenPlusCareCharge = new CarePackageReclaim
            {
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks,
                Status = ReclaimStatus.Active,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30),
                Id = reclaimId,
                CarePackageId = packageId,
                ClaimCollector = ClaimCollector.Supplier
            };
            var package = new CarePackage
            {
                Id = packageId,
                PackageType = PackageType.ResidentialCare,
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = _today.AddDays(-40),
                        EndDate = _today.AddDays(30)
                    }
                },
                Reclaims =
                {
                    thirteenPlusCareCharge
                }
            };

            _carePackageGateway
               .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(package);
            _carePackageReclaimGateway
               .Setup(g => g.GetAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
               .ReturnsAsync(thirteenPlusCareCharge);

            await _useCase.UpdateAsync(new CarePackageReclaimUpdateDomain
            {
                Cost = 2m,
                StartDate = _today.AddDays(-40),
                EndDate = _today.AddDays(30),
                Id = reclaimId,
                ClaimCollector = ClaimCollector.Hackney,
                ClaimReason = "Reason updated",
                Description = "Description updated"
            });

            package.Reclaims.Count.Should().Be(1);
            package.Reclaims.First().Cost.Should().Be(2m);
            package.Reclaims.First().Description.Should().NotBeNullOrEmpty();
            package.Reclaims.First().ClaimReason.Should().NotBeNullOrEmpty();
            package.Reclaims.First().ClaimCollector.Should().Be(ClaimCollector.Hackney);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldAllowUpdateCareChargeProvisionalItemIfNoOverlap()
        {
            var packageId = Guid.NewGuid();
            var reclaimId = Guid.NewGuid();
            var provisionalCareCharge = new CarePackageReclaim
            {
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeProvisional,
                Status = ReclaimStatus.Active,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30),
                Id = reclaimId,
                CarePackageId = packageId,
                ClaimCollector = ClaimCollector.Supplier
            };
            var package = new CarePackage
            {
                Id = packageId,
                PackageType = PackageType.ResidentialCare,
                Details =
                {
                    new CarePackageDetail
                    {
                        Cost = 34.12m,
                        Type = PackageDetailType.CoreCost,
                        StartDate = _today.AddDays(-40),
                        EndDate = _today.AddDays(30)
                    }
                },
                Reclaims =
                {
                    provisionalCareCharge
                }
            };

            _carePackageGateway
               .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(package);
            _carePackageReclaimGateway
                .Setup(g => g.GetAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
                .ReturnsAsync(provisionalCareCharge);

            await _useCase.UpdateAsync(new CarePackageReclaimUpdateDomain
            {
                Cost = 2m,
                StartDate = _today.AddDays(-40),
                EndDate = _today.AddDays(30),
                Id = reclaimId,
                ClaimCollector = ClaimCollector.Hackney,
                ClaimReason = "Reason updated",
                Description = "Description updated"
            });

            package.Reclaims.Count.Should().Be(1);
            package.Reclaims.First().Cost.Should().Be(2m);
            package.Reclaims.First().Description.Should().NotBeNullOrEmpty();
            package.Reclaims.First().ClaimReason.Should().NotBeNullOrEmpty();
            package.Reclaims.First().ClaimCollector.Should().Be(ClaimCollector.Hackney);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldNotAllowUpdateCareChargeProvisionalItemIfThereIsExistReclaim()
        {
            var packageId = Guid.NewGuid();
            var reclaimId = Guid.NewGuid();
            var provisionalCareCharge = new CarePackageReclaim
            {
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = ReclaimSubType.CareChargeProvisional,
                Status = ReclaimStatus.Cancelled,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(-20),
                Id = reclaimId,
                CarePackageId = packageId,
                ClaimCollector = ClaimCollector.Supplier
            };
            var package = new CarePackage
            {
                Id = packageId,
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
                    provisionalCareCharge
                    ,
                    new CarePackageReclaim
                    {
                        Cost = 1m,
                        Type = ReclaimType.CareCharge,
                        SubType = ReclaimSubType.CareChargeWithoutPropertyOneToTwelveWeeks,
                        Status = ReclaimStatus.Active,
                        StartDate = _today.AddDays(-20),
                        EndDate = _today.AddDays(20),
                        Id = Guid.NewGuid(),
                        CarePackageId = packageId,
                        ClaimCollector = ClaimCollector.Supplier
                    }
                }
            };

            _carePackageGateway
               .Setup(g => g.GetPackageAsync(package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
               .ReturnsAsync(package);

            _carePackageReclaimGateway
               .Setup(g => g.GetAsync(It.IsAny<Guid>(), It.IsAny<bool>()))
               .ReturnsAsync(provisionalCareCharge);

            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _useCase.UpdateAsync(new CarePackageReclaimUpdateDomain
                {
                    Cost = 2m,
                    StartDate = _today.AddDays(-10),
                    EndDate = _today.AddDays(25),
                    Id = reclaimId,
                    ClaimCollector = ClaimCollector.Hackney,
                    ClaimReason = "Reason updated",
                    Description = "Description updated"
                });
            });

            //TODO: Fix with correct value
            exception.StatusCode.Should().Be(400);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

    }
}
