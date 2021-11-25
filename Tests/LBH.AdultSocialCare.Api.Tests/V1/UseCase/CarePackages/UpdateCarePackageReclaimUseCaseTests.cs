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
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class UpdateCarePackageReclaimUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly List<Guid> _requestedIds;
        private readonly CarePackage _package;
        private readonly UpdateCarePackageReclaimUseCase _useCase;
        private readonly Mock<IFileStorage> _fileStorage;

        public UpdateCarePackageReclaimUseCaseTests()
        {
            var carePackageReclaimGateway = new Mock<ICarePackageReclaimGateway>();
            var carePackageGateway = new Mock<ICarePackageGateway>();
            _dbManager = new Mock<IDatabaseManager>();
            _fileStorage = new Mock<IFileStorage>();

            _requestedIds = 3.ItemsOf(Guid.NewGuid);

            var packageId = Guid.NewGuid();
            _package = new CarePackage
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

            carePackageReclaimGateway
                .Setup(g => g.GetListAsync(It.IsAny<IEnumerable<Guid>>()))
                .ReturnsAsync(((IEnumerable<Guid> ids) => _package.Reclaims.Where(r => ids.Contains(r.Id)).ToList()));
            carePackageGateway
                .Setup(g => g.GetPackageAsync(_package.Id, PackageFields.Details, true))
                .ReturnsAsync(_package);

            _useCase = new UpdateCarePackageReclaimUseCase(carePackageReclaimGateway.Object, carePackageGateway.Object, _dbManager.Object, Mapper, _fileStorage.Object);
        }

        [Fact]
        public async Task ShouldUpdateProvisionalReclaims()
        {
            const decimal newCost = 34.56m;

            var provisionalReclaim = _package.Reclaims.First();
            provisionalReclaim.SubType = ReclaimSubType.CareChargeProvisional;

            await _useCase.UpdateListAsync(null, new[]
            {
                new CarePackageReclaimUpdateDomain
                {
                    Id = provisionalReclaim.Id,
                    Cost = newCost
                }
            });

            _package.Reclaims.Count.Should().Be(_package.Reclaims.Count, "No new reclaims should be created when updating provisional one");

            _package.Reclaims.Should().ContainSingle(reclaim =>
                reclaim.Cost == newCost &&
                reclaim.SubType == ReclaimSubType.CareChargeProvisional &&
                reclaim.StartDate == _package.Details.First().StartDate, "Provisional reclaim start date should be equal to package start date");

            _package.Reclaims
                .Where(reclaim => reclaim.SubType != ReclaimSubType.CareChargeProvisional)
                .Should().OnlyContain(reclaim =>
                    reclaim.Cost != newCost &&
                    reclaim.StartDate != _package.Details.First().StartDate, "Non-provisional reclaims shouldn't be updated");
        }

        [Fact]
        public async Task ShouldEndExistingReclaimsAndCreateNewOnes()
        {
            const decimal newCost = 34.56m;

            await _useCase.UpdateListAsync(null, _requestedIds.Select(id => new CarePackageReclaimUpdateDomain
            {
                Id = id,
                Cost = newCost
            }).ToList());

            _package.Reclaims
                .Where(reclaim => _requestedIds.Contains(reclaim.Id))
                .Should().OnlyContain(reclaim => reclaim.Status == ReclaimStatus.Ended);
            _package.Reclaims
                .Where(reclaim => reclaim.Status != ReclaimStatus.Ended)
                .Should().OnlyContain(reclaim => reclaim.Cost == newCost && !_requestedIds.Contains(reclaim.Id));

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldFailOnMissingReclaim()
        {
            _useCase
                .Invoking(useCase => useCase.UpdateListAsync(null, 2.ItemsOf(() => new CarePackageReclaimUpdateDomain
                {
                    Id = Guid.NewGuid()
                }).ToList()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void ShouldFailOnCancelledReclaim()
        {
            _package.Reclaims.First().Status = ReclaimStatus.Cancelled;

            var request = _requestedIds.Select(id => new CarePackageReclaimUpdateDomain { Id = id }).ToList();

            _useCase
                .Invoking(useCase => useCase.UpdateListAsync(null, request))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status500InternalServerError);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
