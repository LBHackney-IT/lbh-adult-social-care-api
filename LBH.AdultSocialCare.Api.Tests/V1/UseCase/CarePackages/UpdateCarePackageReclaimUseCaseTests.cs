using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.Tests.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class UpdateCarePackageReclaimUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly List<Guid> _requestedIds;
        private readonly CarePackage _package;
        private readonly UpdateCarePackageReclaimUseCase _useCase;

        public UpdateCarePackageReclaimUseCaseTests()
        {
            var carePackageReclaimGateway = new Mock<ICarePackageReclaimGateway>();
            var carePackageGateway = new Mock<ICarePackageGateway>();
            _dbManager = new Mock<IDatabaseManager>();

            _requestedIds = 3.ItemsOf(Guid.NewGuid);

            var packageId = Guid.NewGuid();
            _package = new CarePackage
            {
                Id = packageId,
                Reclaims = _requestedIds.Select(id => new CarePackageReclaim
                {
                    Id = id,
                    Cost = 12.34m,
                    CarePackageId = packageId,
                    Type = ReclaimType.CareCharge,
                    SubType = ReclaimSubType.CareChargeWithoutPropertyThirteenPlusWeeks
                }).ToList()
            };

            carePackageReclaimGateway
                .Setup(g => g.GetListAsync(It.IsAny<IEnumerable<Guid>>()))
                .ReturnsAsync(new List<CarePackageReclaim>());
            carePackageReclaimGateway
                .Setup(g => g.GetListAsync(_requestedIds))
                .ReturnsAsync(_package.Reclaims.ToList);
            carePackageGateway
                .Setup(g => g.GetPackageAsync(_package.Id, PackageFields.None, true))
                .ReturnsAsync(_package);

            _useCase = new UpdateCarePackageReclaimUseCase(carePackageReclaimGateway.Object, carePackageGateway.Object, _dbManager.Object, Mapper);
        }

        [Fact]
        public async Task ShouldUpdateProvisionalReclaims()
        {
            const decimal newCost = 34.56m;

            foreach (var reclaim in _package.Reclaims)
            {
                reclaim.SubType = ReclaimSubType.CareChargeProvisional;
            }

            await _useCase.UpdateListAsync(_requestedIds.Select(id => new CarePackageReclaimUpdateDomain
            {
                Id = id,
                Cost = newCost
            }).ToList());

            _package.Reclaims.Count.Should().Be(_requestedIds.Count);
            _package.Reclaims.Should().OnlyContain(reclaim =>
                _requestedIds.Contains(reclaim.Id) &&
                reclaim.Cost == newCost &&
                reclaim.SubType == ReclaimSubType.CareChargeProvisional);
        }

        [Fact]
        public async Task ShouldEndExistingReclaimsAndCreateNewOnes()
        {
            const decimal newCost = 34.56m;

            await _useCase.UpdateListAsync(_requestedIds.Select(id => new CarePackageReclaimUpdateDomain
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
                .Invoking(useCase => useCase.UpdateListAsync(2.ItemsOf(() => new CarePackageReclaimUpdateDomain
                {
                    Id = Guid.NewGuid()
                }).ToList()))
                .Should().Throw<ApiException>()
                .Where(ex => ex.StatusCode == StatusCodes.Status404NotFound);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }
    }
}
