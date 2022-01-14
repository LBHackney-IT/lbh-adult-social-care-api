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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.TestFramework.Extensions;
using Xunit;
using UserConstants = LBH.AdultSocialCare.Data.Constants.UserConstants;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.CarePackages
{
    public class UpsertCareChargesUseCaseTests : BaseTest
    {
        private readonly Mock<IDatabaseManager> _dbManager;
        private readonly IUpsertCareChargesUseCase _useCase;

        private readonly CarePackage _package;
        private readonly CarePackageDetail _coreCost;

        private readonly DateTimeOffset _today = DateTimeOffset.UtcNow.Date;

        public UpsertCareChargesUseCaseTests()
        {
            _coreCost = new CarePackageDetail
            {
                Cost = 34.12m,
                Type = PackageDetailType.CoreCost,
                StartDate = _today.AddDays(-30),
                EndDate = _today.AddDays(30)
            };

            _package = new CarePackage
            {
                Id = Guid.NewGuid(),
                PackageType = PackageType.ResidentialCare,
                Details = { _coreCost },
                Settings = new CarePackageSettings()
            };

            _dbManager = new Mock<IDatabaseManager>();

            var carePackageGateway = new Mock<ICarePackageGateway>();
            carePackageGateway
                .Setup(g => g.GetPackageAsync(_package.Id, It.IsAny<PackageFields>(), It.IsAny<bool>()))
                .ReturnsAsync(_package);

            _useCase = new UpsertCareChargesUseCase(carePackageGateway.Object, _dbManager.Object, Mapper);
        }

        [Fact]
        public async Task ShouldSaveValidChargesList()
        {
            _coreCost.EndDate = _today.AddDays(300);

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _today.AddDays(-1)),
                (ReclaimSubType.CareCharge1To12Weeks, _today, _today.AddDays(84)),
                (ReclaimSubType.CareCharge13PlusWeeks, _today.AddDays(85), _today.AddDays(200)));

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(3);

            foreach (var requestedCharge in request.CareCharges)
            {
                _package.Reclaims.Should().ContainSingle(
                    r => r.SubType == requestedCharge.SubType &&
                         r.StartDate == requestedCharge.StartDate &&
                         r.EndDate == requestedCharge.EndDate);
            }

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldReplaceUpdatedChargeWithNewOneWhenDateIsChanged()
        {
            AddExistingCareCharge(ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _today);
            AddExistingCareCharge(ReclaimSubType.CareCharge1To12Weeks, _today.AddDays(1), _coreCost.EndDate);

            var request = CreateUpsertRequest();
            request.CareCharges.First().EndDate = _today.AddDays(-1);
            request.CareCharges.Last().StartDate = _today;

            await _useCase.ExecuteAsync(_package.Id, request);

            var provisionalCharges = _package.Reclaims.Where(r => r.SubType is ReclaimSubType.CareChargeProvisional).ToList();
            var first12WeeksCharges = _package.Reclaims.Where(r => r.SubType is ReclaimSubType.CareCharge1To12Weeks).ToList();

            provisionalCharges.Count.Should().Be(2);
            first12WeeksCharges.Count.Should().Be(2);

            provisionalCharges.Should().ContainSingle(c => c.StartDate == _coreCost.StartDate && c.EndDate == _today && c.Status == ReclaimStatus.Cancelled);
            provisionalCharges.Should().ContainSingle(c => c.StartDate == _coreCost.StartDate && c.EndDate == _today.AddDays(-1) && c.Status == ReclaimStatus.Ended);

            first12WeeksCharges.Should().ContainSingle(c => c.StartDate == _today.AddDays(1) && c.EndDate == _coreCost.EndDate && c.Status == ReclaimStatus.Cancelled);
            first12WeeksCharges.Should().ContainSingle(c => c.StartDate == _today && c.EndDate == _coreCost.EndDate && c.Status == ReclaimStatus.Active);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldReplaceUpdatedChargeWithNewOneWhenCostIsChanged()
        {
            _coreCost.EndDate = _today.AddDays(1000);

            AddExistingCareCharge(ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate, _coreCost.StartDate.AddDays(84));
            AddExistingCareCharge(ReclaimSubType.CareCharge13PlusWeeks, _coreCost.StartDate.AddDays(85), _coreCost.EndDate);

            _package.Reclaims.Last().Cost = 10m;

            var request = CreateUpsertRequest();
            request.CareCharges.Last().Cost = 20m;

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(3);

            var plus13WeeksCharges = _package.Reclaims.Where(r => r.SubType is ReclaimSubType.CareCharge13PlusWeeks).ToList();

            plus13WeeksCharges.Should().ContainSingle(c => c.Cost == 20m && c.Status == ReclaimStatus.Pending);
            plus13WeeksCharges.Should().ContainSingle(c => c.Cost == 10m && c.Status == ReclaimStatus.Cancelled);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldReplaceUpdatedChargeWithNewOneWhenCollectorIsChanged()
        {
            AddExistingCareCharge(ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _coreCost.EndDate);
            _package.Reclaims.Single().ClaimCollector = ClaimCollector.Supplier;

            var request = CreateUpsertRequest();
            request.CareCharges.Single().ClaimCollector = ClaimCollector.Hackney;

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(2);

            _package.Reclaims.Should().ContainSingle(c => c.ClaimCollector == ClaimCollector.Hackney && c.Status == ReclaimStatus.Active);
            _package.Reclaims.Should().ContainSingle(c => c.ClaimCollector == ClaimCollector.Supplier && c.Status == ReclaimStatus.Cancelled);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldKeepProvisionalChargeWhenAddingSuccessive12WeeksCharge()
        {
            AddExistingCareCharge(ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _today.AddDays(5));

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareCharge1To12Weeks, _today.AddDays(6), _coreCost.EndDate));

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(2);

            _package.Reclaims.Should().ContainSingle(
                r => r.SubType == ReclaimSubType.CareChargeProvisional &&
                     r.Status == ReclaimStatus.Active &&
                     r.StartDate == _coreCost.StartDate &&
                     r.EndDate == _today.AddDays(5));

            _package.Reclaims.Should().ContainSingle(
                r => r.SubType == ReclaimSubType.CareCharge1To12Weeks &&
                     r.Status == ReclaimStatus.Pending &&
                     r.StartDate == _today.AddDays(6) &&
                     r.EndDate == _coreCost.EndDate);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task ShouldCancelledProvisionalChargeWhenAddingReplacing12WeeksCharge()
        {
            AddExistingCareCharge(ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _today.AddDays(5));

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate, _coreCost.EndDate));

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(2);

            _package.Reclaims.Should().ContainSingle(
                r => r.SubType == ReclaimSubType.CareChargeProvisional &&
                     r.Status == ReclaimStatus.Cancelled);

            _package.Reclaims.Should().ContainSingle(
                r => r.SubType == ReclaimSubType.CareCharge1To12Weeks &&
                     r.Status == ReclaimStatus.Active);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Theory]
        [InlineData(ReclaimSubType.CareChargeProvisional)]
        [InlineData(ReclaimSubType.CareCharge1To12Weeks)]
        public async Task ShouldAdjustOngoingCareChargeEndDateToFinitePackageEndDate(ReclaimSubType subtype)
        {
            var request = CreateUpsertRequest((subtype, _coreCost.StartDate, null));

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims
                .Single(r => r.SubType == subtype)
                .EndDate.Should().Be(_coreCost.EndDate);
        }

        [Fact]
        public async Task ShouldAdjustOngoing13PlusWeeksChargeEndDateToFinitePackageEndDate()
        {
            _coreCost.EndDate = _today.AddDays(300);

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate, _coreCost.StartDate.AddDays(84)),
                (ReclaimSubType.CareCharge13PlusWeeks, _coreCost.StartDate.AddDays(85), null));

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims
                .Single(r => r.SubType is ReclaimSubType.CareCharge13PlusWeeks)
                .EndDate.Should().Be(_coreCost.EndDate);
        }

        [Fact]
        public void ShouldFailWhenAdding12WeeksChargeForMoreThan12WeeksPeriod()
        {
            _coreCost.EndDate = _today.AddDays(300);

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate, _coreCost.StartDate.AddDays(20 * 7)));

            VerifyFailedRequest(request, "cannot exceed 12 weeks");
        }

        [Fact]
        public void ShouldFailWhenAdding12WeeksChargeForLessThan12WeeksPeriodForLongPackage()
        {
            _coreCost.EndDate = _today.AddDays(3000);

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate, _coreCost.StartDate.AddDays(2 * 7)));

            VerifyFailedRequest(request, "should end at");
        }

        [Fact]
        public async Task ShouldAllowCreating12WeeksChargeForShorterPackage()
        {
            _coreCost.EndDate = _coreCost.StartDate.AddDays(5);

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate, _coreCost.EndDate));

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(1);
            _package.Reclaims.Should().ContainSingle(
                r => r.SubType == ReclaimSubType.CareCharge1To12Weeks &&
                     r.Status == ReclaimStatus.Ended &&
                     r.StartDate == _coreCost.StartDate &&
                     r.EndDate == _coreCost.EndDate);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ShouldFailOnOverlappingCareCharges()
        {
            var request = CreateUpsertRequest(
                (ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _today.AddDays(5)),
                (ReclaimSubType.CareCharge1To12Weeks, _today.AddDays(5), _coreCost.EndDate));

            VerifyFailedRequest(request, "must start one day after");
        }

        [Fact]
        public void ShouldFailOnGapsBetweenCareCharges()
        {
            _coreCost.EndDate = _today.AddDays(300);

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate, _coreCost.StartDate.AddDays(84)),
                (ReclaimSubType.CareCharge13PlusWeeks, _coreCost.StartDate.AddDays(90), _coreCost.EndDate));

            VerifyFailedRequest(request, "must start one day after");
        }

        [Fact]
        public void ShouldFailWhenOngoingChargeFollowedByAnotherCharge()
        {
            var request = CreateUpsertRequest(
                (ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, null),
                (ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate.AddDays(10), _coreCost.EndDate));

            VerifyFailedRequest(request, "care charge must have an end date");
        }

        [Theory]
        [InlineData(ReclaimSubType.CareChargeProvisional, -1)]
        [InlineData(ReclaimSubType.CareChargeProvisional, 1)]
        [InlineData(ReclaimSubType.CareCharge1To12Weeks, -1)]
        [InlineData(ReclaimSubType.CareCharge1To12Weeks, 1)]
        public void ShouldFailWhenFirstCareChargeStartDateDiffersFromPackageStartDate(ReclaimSubType subtype, int daysDelta)
        {
            var request = CreateUpsertRequest(
                (subtype, _coreCost.StartDate.AddDays(daysDelta), null));

            VerifyFailedRequest(request, "First care charge must start on package start date");
        }

        [Theory]
        [InlineData(ReclaimSubType.CareChargeProvisional)]
        [InlineData(ReclaimSubType.CareCharge1To12Weeks)]
        public void ShouldFailWhenLastCareChargeEndDateExceedsPackageEndDate(ReclaimSubType subtype)
        {
            var request = CreateUpsertRequest((subtype, _coreCost.StartDate, _coreCost.EndDate?.AddDays(1)));

            VerifyFailedRequest(request, "Last care charge end date expected to be less than or equal to");
        }

        [Fact]
        public void ShouldFailWhen13PlusWeeksCareChargeEndDateExceedsPackageEndDate()
        {
            _coreCost.EndDate = _today.AddDays(300);

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate, _coreCost.StartDate.AddDays(84)),
                (ReclaimSubType.CareCharge13PlusWeeks, _coreCost.StartDate.AddDays(85), _coreCost.EndDate?.AddDays(1)));

            VerifyFailedRequest(request, "Last care charge end date expected to be less than or equal to");
        }

        [Fact]
        public void ShouldFailWhenProvisionalChargeFollowedBy13PlusCharge()
        {
            var request = CreateUpsertRequest(
                (ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _coreCost.StartDate.AddDays(10)),
                (ReclaimSubType.CareCharge13PlusWeeks, _coreCost.StartDate.AddDays(11), _coreCost.EndDate));

            VerifyFailedRequest(request, "care charge must be followed by");
        }

        [Fact]
        public async Task ShouldAllowProvisionalChargeFollowedBy13PlusChargeForMigratedPackage()
        {
            _package.CreatorId = UserConstants.MigrationUserId;

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _today.AddDays(5)),
                (ReclaimSubType.CareCharge13PlusWeeks, _today.AddDays(6), _coreCost.EndDate));

            await _useCase.ExecuteAsync(_package.Id, request);

            _package.Reclaims.Count.Should().Be(2);

            _package.Reclaims.Should().ContainSingle(
                r => r.SubType == ReclaimSubType.CareChargeProvisional &&
                     r.Status == ReclaimStatus.Active);

            _package.Reclaims.Should().ContainSingle(
                r => r.SubType == ReclaimSubType.CareCharge13PlusWeeks &&
                     r.Status == ReclaimStatus.Pending);

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Once);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-10)]
        public void ShouldFailWhenProvisionalAnd13PlusChargeNonAdjacentInMigratedPackage(int daysDelta)
        {
            _package.CreatorId = UserConstants.MigrationUserId;
            _coreCost.EndDate = _today.AddDays(300);

            AddExistingCareCharge(
                ReclaimSubType.CareCharge13PlusWeeks, _coreCost.StartDate.AddDays(85), _coreCost.EndDate);

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _coreCost.StartDate.AddDays(85 + daysDelta)));

            VerifyFailedRequest(request, "must start one day after");
        }

        [Fact]
        public void ShouldFailWhenExistingCareChargeAbsentInRequest()
        {
            _coreCost.EndDate = _coreCost.EndDate.GetValueOrDefault().AddDays(1000);

            AddExistingCareCharge(ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _coreCost.StartDate.AddDays(10));
            AddExistingCareCharge(ReclaimSubType.CareCharge1To12Weeks, _coreCost.StartDate.AddDays(11), _coreCost.StartDate.AddDays(95));
            AddExistingCareCharge(ReclaimSubType.CareCharge13PlusWeeks, _coreCost.StartDate.AddDays(96), _coreCost.EndDate);

            foreach (var subtype in _package.Reclaims.Select(r => r.SubType))
            {
                var request = CreateUpsertRequest();
                request.CareCharges.Remove(request.CareCharges.First(r => r.SubType == subtype));

                VerifyFailedRequest(request, "must present in the request with valid Id");
            }
        }

        [Fact]
        public void ShouldFailWhenRequestContainsNonUniqueSubtypes()
        {
            AddExistingCareCharge(ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _coreCost.StartDate.AddDays(10));

            var request = CreateUpsertRequest();
            request.CareCharges.Add(request.CareCharges.First().DeepCopy());

            VerifyFailedRequest(request, "Not allowed to have more than one");
        }

        [Fact]
        public void ShouldFailWhenServiceUserIsS1117()
        {
            _package.Settings.IsS117Client = true;

            var request = CreateUpsertRequest(
                (ReclaimSubType.CareChargeProvisional, _coreCost.StartDate, _coreCost.StartDate.AddDays(10)));

            VerifyFailedRequest(request, "service user under S1117");
        }

        #region Utils

        private void VerifyFailedRequest(CareChargesCreateDomain request, string message)
        {
            _useCase
                .Invoking(async useCase => await useCase.ExecuteAsync(_package.Id, request))
                .Should().Throw<ApiException>()
                .Where(ex => ex.Message.Contains(message));

            _dbManager.Verify(db => db.SaveAsync(It.IsAny<string>()), Times.Never);
        }

        private void AddExistingCareCharge(ReclaimSubType subType, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            _package.Reclaims.Add(new CarePackageReclaim
            {
                Id = Guid.NewGuid(),
                CarePackageId = _package.Id,
                Type = ReclaimType.CareCharge,
                SubType = subType,
                Status = ReclaimStatus.Active,
                ClaimCollector = ClaimCollector.Supplier,
                Cost = 1m,
                StartDate = startDate,
                EndDate = endDate
            });
        }

        private CareChargesCreateDomain CreateUpsertRequest(params (ReclaimSubType subtype, DateTimeOffset startDate, DateTimeOffset? endDate)[] newCharges)
        {
            var request = new CareChargesCreateDomain { CareCharges = new List<CareChargeReclaimCreationDomain>() };

            // TODO: VK: Reorganize and unify reclaim creation entities, use mapper
            foreach (var careCharge in _package.Reclaims.Where(r => r.Type is ReclaimType.CareCharge))
            {
                request.CareCharges.Add(
                    new CareChargeReclaimCreationDomain
                    {
                        Id = careCharge.Id,
                        CarePackageId = careCharge.CarePackageId,
                        Type = careCharge.Type,
                        SubType = careCharge.SubType.GetValueOrDefault(),
                        Status = careCharge.Status,
                        Cost = careCharge.Cost,
                        Description = careCharge.Description,
                        ClaimCollector = careCharge.ClaimCollector,
                        ClaimReason = careCharge.ClaimReason,
                        StartDate = careCharge.StartDate,
                        EndDate = careCharge.EndDate
                    });
            }

            foreach (var newCareCharge in newCharges)
            {
                AddRequestedCareCharge(request, newCareCharge.subtype, newCareCharge.startDate, newCareCharge.endDate);
            }

            return request;
        }

        private void AddRequestedCareCharge(CareChargesCreateDomain request, ReclaimSubType subType, DateTimeOffset startDate, DateTimeOffset? endDate = null)
        {
            request.CareCharges.Add(new CareChargeReclaimCreationDomain
            {
                CarePackageId = _package.Id,
                Cost = 1m,
                Type = ReclaimType.CareCharge,
                SubType = subType,
                StartDate = startDate,
                EndDate = endDate,
                Status = ReclaimStatus.Active,
                ClaimCollector = ClaimCollector.Supplier
            });
        }

        #endregion Utils
    }
}
